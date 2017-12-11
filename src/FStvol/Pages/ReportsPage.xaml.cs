using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FStvol.ViewModels;
using Tvol.Data;

namespace FStvol.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReportsPage : ContentPage
	{
        ReportsViewModel ViewModel
        {
            get { return BindingContext as ReportsViewModel; }
        }

        public ReportsPage ()
		{
			InitializeComponent ();
		}

        public void _reportsListView_ItemSelected(object sender, SelectedItemChangedEventArgs ea)
        {
            var report = (Report)ea.SelectedItem;
            if(report == null) { return;}

            ViewModel?.SelectReportCommad.Execute(report);

            _reportsListView.SelectedItem = null;
        }
    }
}