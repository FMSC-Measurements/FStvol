using FStvol.Pages;
using System;
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
            var vm = new ReportsViewModel(Database);
            vm.NavigationService = NavigationService;

            var view = new ReportsPage();
            view.BindingContext = vm;
            vm.Init(null);

            NavigationService.PushAsync(view);
        }

        private void ShowProfiles(object obj)
        {
            var vm = new ProfilesViewModel(Database);
            vm.NavigationService = this.NavigationService;

            var view = new ProfilesPage();
            view.BindingContext = vm;
            vm.Init(null);

            NavigationService.PushAsync(view);
        }

        private void ShowTrees(object obj)
        {
            var vm = new TreeViewModel(Database);
            vm.NavigationService = this.NavigationService;

            var view = new TreePage();
            view.BindingContext = vm;
            vm.Init(null);

            NavigationService.PushAsync(view);
        }
    }
}