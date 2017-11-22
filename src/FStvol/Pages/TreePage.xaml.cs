using FStvol.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FStvol.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TreePage : ContentPage
	{
        private TreeViewModel _viewModel;

        public TreeViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                OnViewModelChanging();
                _viewModel = value;
                OnViewModelChanged();
            }
        }

        private void OnViewModelChanged()
        {
            var vm = ViewModel;
            if(vm != null)
            {
                vm.PropertyChanged -= ViewModel_PropertyChanged;
            }
        }

        private void OnViewModelChanging()
        {
            var vm = ViewModel;
            if(vm != null)
            {
                vm.PropertyChanged += ViewModel_PropertyChanged;
            }
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(TreeViewModel.TreeProfiles))
            {

            }
        }

        public TreePage ()
		{
			InitializeComponent ();
		}

        
	}
}