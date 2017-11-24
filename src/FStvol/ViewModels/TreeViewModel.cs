using Dapper;
using Dapper.Contrib.Extensions;
using FStvol.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tvol.Data;
using Xamarin.Forms;

namespace FStvol.ViewModels
{
    public class TreeViewModel : ViewModelBase
    {
        private Command _addTreeCommand;
        private Command _deleteTreeCommand;
        private Command<Tree> _selectTreeCommand;
        private ObservableCollection<Tree> _trees;
        private List<TreeProfile> _treeProfiles;
        private Tree _currentTree;

        public ObservableCollection<Tree> Trees
        {
            get { return _trees; }
            set { SetValue(ref _trees, value); }
        }

        public List<TreeProfile> TreeProfiles
        {
            get { return _treeProfiles; }
            set { SetValue(ref _treeProfiles, value); }
        }

        public TvolDatabase Database { get; private set; }

        public ICommand AddTreeCommand => _addTreeCommand = new Command(AddTree);
        public ICommand DeleteTreeCommand => _deleteTreeCommand = new Command(DeleteTree);
        public ICommand SelectTreeCommand => _selectTreeCommand = new Command<Tree>(SelectTree);



        public Tree CurrentTree
        {
            get { return _currentTree; }
            set
            {
                SetValue(ref _currentTree, value);
                NotifyPropertyChanged(nameof(CurrentTreeProfileIndex));
            }
        }

        public int CurrentTreeProfileIndex
        {
            get
            {
                if (CurrentTree == null) { return -1; }
                else { return TreeProfiles.FindIndex(x => x.Product == CurrentTree.Product && x.Species == CurrentTree.Species); }
            }
            set
            {
                if (CurrentTree != null)
                {
                    if(value < 0)
                    { return; }

                    var profile = TreeProfiles[value];
                    CurrentTree.Species = profile.Species;
                    CurrentTree.Product = profile.Product;
                }
                NotifyPropertyChanged();
            }
        }

        //public Tree NewTree { get; set; }

        public TreeViewModel(TvolDatabase database)
        {
            Database = database;
        }

        public override void Init(object data)
        {
            using (var conn = Database.OpenConnection())
            {
                Trees = conn.Query<Tree>("SELECT * FROM Tree;").ToObservableCollection();
                foreach(var tree in Trees)
                {
                    tree.PropertyChanged += Tree_PropertyChanged;
                }

                TreeProfiles = conn.Query<TreeProfile>("SELECT * FROM TreeProfile;").ToList();
            }
            CurrentTree = null;
        }

        private void AddTree(object obj)
        {
            var newTree = new Tree();
            newTree.PropertyChanged += Tree_PropertyChanged;

            using (var conn = Database.OpenConnection())
            {
                conn.Execute("PRAGMA foreign_keys = off;");
                conn.Insert(newTree);
                conn.Execute("PRAGMA foreign_keys = on;");
            }
            Trees.Add(newTree);
            CurrentTree = newTree;

        }

        private void Tree_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var tree = (Tree)sender;
            using (var conn = Database.OpenConnection()) 
            {

                conn.Execute("PRAGMA foreign_keys = off;");
                conn.Update(tree);
                conn.Execute("PRAGMA foreign_keys = on;");
            }
        }

        private void DeleteTree()
        {
            var tree = CurrentTree;
            if(tree != null)
            {
                using (var conn = Database.OpenConnection())
                {
                    conn.Delete(tree);

                    Trees.Remove(tree);
                    //CurrentTree = Trees.FirstOrDefault();
                    CurrentTree = null;
                }
            }
        }

        private void SelectTree(Tree obj)
        {
            throw new NotImplementedException();
        }

        public static void SaveTree(Tree tree)
        {

        }
    }
}
