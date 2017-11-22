using FStvol.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tvol.Data;
using Xamarin.Forms;

namespace FStvol.ViewModels
{
    public class TvolLandingViewModel : ViewModelBase
    {
        private Command _showTreesCommand;
        private Command _showProfilesCommand;
        private Command _showReportsCommand;

        public TvolLandingViewModel(TvolDatabase database)
        {
            Database = database;
        }

        public override void Init(object data)
        {

        }

        public ICommand ShowTreesCommand => _showTreesCommand = new Command(ShowTrees);
        public ICommand ShowProfilesCommand => _showProfilesCommand = new Command(ShowProfiles);
        public ICommand ShowReportsCommand => _showReportsCommand = new Command(ShowReports);

        public TvolDatabase Database { get; private set; }

        private void ShowReports(object obj)
        {
            throw new NotImplementedException();
        }

        private void ShowProfiles(object obj)
        {
            throw new NotImplementedException();
        }

        private void ShowTrees(object obj)
        {            
            var vm = new TreeViewModel(Database);
            var view = new TreePage();
            view.BindingContext = vm;
            vm.Init(null);
            vm.NavigationService = this.NavigationService;

            NavigationService.PushAsync(view);
        }
    }
}
