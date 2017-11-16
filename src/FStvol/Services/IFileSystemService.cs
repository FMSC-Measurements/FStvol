using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FStvol.Services
{
    public interface IFileSystemService
    {
        //String DocumentsPath { get; }

        IEnumerable<System.IO.FileInfo> GetFiles();

    }
}
