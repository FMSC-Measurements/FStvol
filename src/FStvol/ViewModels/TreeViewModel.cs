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
        private Command<Tree> _deleteTreeCommand;
        private Command<Tree> _selectTreeCommand;
        private ObservableCollection<Tree> _trees;
        private ICollection<TreeProfile> _treeProfiles;
        private Tree _currentTree;

        public ObservableCollection<Tree> Trees
        {
            get { return _trees; }
            set { SetValue(ref _trees, value); }
        }

        public ICollection<TreeProfile> TreeProfiles
        {
            get { return _treeProfiles; }
            set { SetValue(ref _treeProfiles, value); }
        }

        public TvolDatabase Database { get; private set; }

        public ICommand AddTreeCommand => _addTreeCommand = new Command(AddTree);
        public ICommand DeleteTreeCommand => _deleteTreeCommand = new Command<Tree>(DeleteTree);
        public ICommand SelectTreeCommand => _selectTreeCommand = new Command<Tree>(SelectTree);



        public Tree CurrentTree
        {
            get { return _currentTree; }
            set { SetValue(ref _currentTree, value); }
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
                TreeProfiles = conn.Query<TreeProfile>("SELECT * FROM TreeProfile;").ToList();
            }
        }

        private void AddTree(object obj)
        {
            var newTree = new Tree();

            //using (var conn = Database.OpenConnection())
            //{
            //    conn.Insert(newTree);
            //}
            Trees.Add(newTree);
            CurrentTree = newTree;

        }

        private void DeleteTree(Tree obj)
        {
            throw new NotImplementedException();
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
