using FStvol.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tvol.Data;
using Xamarin.Forms;

namespace FStvol.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Command<FileInfo> _selectFileCommand;
        private IEnumerable<FileInfo> _files;

        public IEnumerable<FileInfo> Files
        {
            get { return _files; }
            set
            {
                SetValue(ref _files, value);
            }
        }

        public ICommand SelectFileCommand => _selectFileCommand = new Command<FileInfo>(SelectFile);

        

        public override void Init(object data)
        {
            Files = App.FileSystemService.GetFiles().ToList();
        }

        public void SelectFile(FileInfo file)
        {
            TvolDatabase dataBase = new TvolDatabase(file.FullName);

            var vm = new TvolLandingViewModel(dataBase);
            var view = new TvolLandingPage();
            view.BindingContext = vm;
            vm.Init(null);
            vm.NavigationService = this.NavigationService;

            NavigationService.PushAsync(view);
        }
    }
}
