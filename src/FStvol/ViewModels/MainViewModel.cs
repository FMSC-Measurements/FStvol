using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FStvol.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public IEnumerable<FileInfo> Files { get; set; }


        public override void Init(object data)
        {
            Files = App.FileSystemService.GetFiles().ToList();
        }
    }
}
