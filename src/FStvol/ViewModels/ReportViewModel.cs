using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Linq;
using Tvol.Data;

namespace FStvol.ViewModels
{
    public class ReportViewModel : ViewModelBase
    {
        private List<TreeEntry> _trees;
        private double _calculatedVolume;

        public class TreeEntry
        {
            private bool _isSelected;

            public Tree Tree { get; set; }

            public ReportViewModel ViewModel { get; set; }

            public bool IsSelected
            {
                get { return ViewModel.Tree_Reports.ContainsKey(Tree.TreeID); }
                set { ViewModel.TreeItem_NotifySelectionChanged(this, value); }
            }

            public double Volume { get; set; }
        }

        public TvolDatabase Database { get; private set; }
        public Report Report { get; private set; }

        public double CalculatedVolume
        {
            get { return _calculatedVolume; }
            protected set { SetValue(ref _calculatedVolume, value); }
        }

        public List<Regression> Regressions { get; private set; }

        public List<TreeEntry> Trees
        {
            get { return _trees; }
            set { SetValue(ref _trees, value); }
        }

        

        public Dictionary<int, Tree_Report> Tree_Reports { get; set; } = new Dictionary<int, Tree_Report>();

        public ReportViewModel(TvolDatabase database)
        {
            Database = database;
        }

        protected void TreeItem_NotifySelectionChanged(TreeEntry ti, bool value)
        {
            if (Tree_Reports.ContainsKey(ti.Tree.TreeID) && value == false)
            {
                using (var conn = Database.OpenConnection())
                {
                    var tree_report = Tree_Reports[ti.Tree.TreeID];
                    //conn.Execute($"DELETE FROM Tree_Report WHERE RowID = {tree_report.RowID};");

                    conn.Delete(tree_report);
                    Tree_Reports.Remove(tree_report.TreeID);
                }
            }
            else if (!Tree_Reports.ContainsKey(ti.Tree.TreeID) && value == true)
            {
                using (var conn = Database.OpenConnection())
                {
                    var tree_report = new Tree_Report() { TreeID = ti.Tree.TreeID, ReportID = Report.ReportID };
                    conn.Insert(tree_report);
                    Tree_Reports.Add(tree_report.TreeID, tree_report);
                }
            }

            CalculatedVolume = CalculateVolume();
        }

        public override void Init(object data)
        {
            var report = (Report)data;

            Report = report;

            using (var conn = Database.OpenConnection())
            {
                var treeReports = conn.Query<Tree_Report>($"SELECT * FROM Tree_Report WHERE ReportID = {Report.ReportID};");
                foreach (var tr in treeReports)
                {
                    Tree_Reports.Add(tr.TreeID, tr);
                }

                var trees = conn.Query<Tree>("SELECT * FROM Tree;")
                    .Select(x => new TreeEntry() { Tree = x, ViewModel = this }).ToList();

                Regressions = conn.Query<Regression>("SELECT * FROM Regression;").ToList();

                Trees = trees;
            }

            CalculatedVolume = CalculateVolume();
        }

        public double CalculateVolume()
        {
            var volume = 0.0;

            foreach (var treeEntry in Trees)
            {
                if(treeEntry.IsSelected)
                {
                    var tree = treeEntry.Tree;
                    var regression = Regressions.Where(x => x.Species == treeEntry.Tree.Species
                    && x.LiveDead == tree.LiveDead
                    && x.Product == tree.Product).FirstOrDefault();

                    if(regression != null)
                    {
                        treeEntry.Volume = VolumeCalculator.CalculateVolume(tree, regression);
                    }
                    else
                    {
                        treeEntry.Volume = 0;
                    }
                }
                else
                {
                    treeEntry.Volume = 0;
                }

                volume += treeEntry.Volume;
            }

            return volume;
        }
    }
}