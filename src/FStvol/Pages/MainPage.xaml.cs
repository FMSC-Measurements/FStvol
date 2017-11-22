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
	public partial class MainPage : ContentPage
	{
        private MainViewModel _viewModel;

        MainViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                _viewModel = value;
                OnViewModelChanged();
            }
        }

        private void OnViewModelChanged()
        {
            var viewModel = ViewModel;
            if (viewModel != null)
            {
                BindingContext = viewModel;
                viewModel.Init(null);
            }

        }

        public MainPage ()
		{
			InitializeComponent ();

            ViewModel = new MainViewModel() { NavigationService = Navigation };
		}

        void _fileListView_ItemTapped(object sender, ItemTappedEventArgs ea)
        {
            var file = ea.Item as System.IO.FileInfo;
            if (file != null)
            {
                ViewModel.SelectFile(file);
            }
        }
    }

    
}