using Dapper;
using Dapper.Contrib.Extensions;
using FStvol.Pages;
using FStvol.Util;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Tvol.Data;
using Xamarin.Forms;

namespace FStvol.ViewModels
{
    public class ReportsViewModel : ViewModelBase
    {
        private ObservableCollection<Report> _reports;
        private Command _addReportCommand;
        private Command<Report> _deleteReportCommand;
        private Command<Report> _selectReportCommand;

        public TvolDatabase Database { get; private set; }

        public ObservableCollection<Report> Reports
        {
            get { return _reports; }
            set { SetValue(ref _reports, value); }
        }

        public ICommand AddReportCommand => _addReportCommand = new Command(AddReport);
        public ICommand DeleteReportCommand => _deleteReportCommand = new Command<Report>(DeleteReport);
        public ICommand SelectReportCommad => _selectReportCommand = new Command<Report>(SelectReport);

        

        public ReportsViewModel(TvolDatabase database)
        {
            Database = database;
        }

        public override void Init(object data)
        {
            using (var conn = Database.OpenConnection())
            {
                Reports = conn.Query<Report>("SELECT * FROM Report;").ToObservableCollection();
            }
        }

        private void AddReport(object obj)
        {
            var newReport = new Report() { CreatedDate = DateTime.Now.ToString("M / d / yyyy h:mm tt") };
            using (var conn = Database.OpenConnection())
            {
                conn.Insert(newReport);
                Reports.Add(newReport);
            }
        }

        private void DeleteReport(Report report)
        {
            using (var conn = Database.OpenConnection())
            {
                conn.Delete(report);
                Reports.Remove(report);
            }
        }

        private void SelectReport(Report report)
        {
            var viewModel = new ReportViewModel(Database);
            viewModel.NavigationService = NavigationService;

            var view = new ReportPage();
            view.BindingContext = viewModel;

            viewModel.Init(report);

            NavigationService.PushAsync(view);
        }
    }
}