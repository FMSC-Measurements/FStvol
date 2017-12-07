using Dapper;
using Dapper.Contrib.Extensions;
using FStvol.Util;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Tvol.Data;
using Xamarin.Forms;

namespace FStvol.ViewModels
{
    public class ProfilesViewModel : ViewModelBase
    {
        public TvolDatabase Database { get; set; }

        private ObservableCollection<TreeProfile> _treeProfiles;

        public ObservableCollection<TreeProfile> TreeProfiles
        {
            get { return _treeProfiles; }
            set { SetValue(ref _treeProfiles, value); }
        }

        private TreeProfile _currentTreeProfile;
        private Command _addTreeProfileCommand;
        private Command _deleteTreeProfileCommand;

        public TreeProfile CurrentTreeProfile
        {
            get { return _currentTreeProfile; }
            set { SetValue(ref _currentTreeProfile, value); }
        }

        public ICommand AddTreeProfileCommand => _addTreeProfileCommand = new Command(AddTreeProfile);

        public ICommand DeleteTreeProfileCommand => _deleteTreeProfileCommand = new Command<TreeProfile>(DeleteTreeProfile);

        public ProfilesViewModel(TvolDatabase database)
        {
            Database = database;
        }

        public override void Init(object data)
        {
            using (var conn = Database.OpenConnection())
            {
                TreeProfiles = conn.Query<TreeProfile>("SELECT RowID, * FROM TreeProfile;").ToObservableCollection();
                foreach (var treeProfile in TreeProfiles)
                {
                    treeProfile.PropertyChanged += TreeProfile_PropertyChanged;
                }
                CurrentTreeProfile = null;
            }
        }

        private void TreeProfile_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                var treeProfile = (TreeProfile)sender;
                using (var conn = Database.OpenConnection())
                {
                    conn.Update(treeProfile);
                }
            }
            catch(Microsoft.Data.Sqlite.SqliteException ex)
            {
                if(ex.SqliteErrorCode == 19)
                {
                    App.AlertService.ShowAlert("Profile Can't be modified");
                }
                else
                {
                    throw;
                }
            }
        }

        private void AddTreeProfile(object obj)
        {
            var newTreeProfile = new TreeProfile();

            using (var conn = Database.OpenConnection())
            {
                conn.Insert(newTreeProfile);

                CurrentTreeProfile = newTreeProfile;
                newTreeProfile.PropertyChanged += TreeProfile_PropertyChanged;
                TreeProfiles.Add(newTreeProfile);
            }
        }

        private void DeleteTreeProfile(TreeProfile treeProfile)
        {
            if (treeProfile != null)
            {
                using (var conn = Database.OpenConnection())
                {
                    conn.Delete(treeProfile);

                    TreeProfiles.Remove(treeProfile);
                }
            }
        }
    }
}