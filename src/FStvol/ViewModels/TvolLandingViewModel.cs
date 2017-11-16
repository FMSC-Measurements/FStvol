using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FStvol.ViewModels
{
    public class TvolLandingViewModel : ViewModelBase
    {
        private Command _showTreesCommand;
        private Command _showProfilesCommand;
        private Command _showReportsCommand;

        public TvolLandingViewModel()
        {

        }

        public override void Init(object data)
        {

        }

        public ICommand ShowTreesCommand => _showTreesCommand = new Command(ShowTrees);
        public ICommand ShowProfilesCommand => _showProfilesCommand = new Command(ShowProfiles);
        public ICommand ShowReportsCommand => _showReportsCommand = new Command(ShowReports);

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

        }
    }
}
