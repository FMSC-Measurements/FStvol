using FStvol.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using FStvol.Util;

namespace FStvol.Droid.Services
{
    public class AndroidFileSystemService : IFileSystemService
    {
        public IEnumerable<string> SearchFolders
        {
            get
            {
                yield return Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).AbsolutePath;
                yield return Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath;
            }

        }

        public IEnumerable<FileInfo> GetFiles()
        {
            foreach(var dir in SearchFolders)
            {
                if(System.IO.Directory.Exists(dir))
                {
                    foreach(var file in System.IO.Directory.EnumerateFiles(dir, "*.tvol"))
                    {
                        yield return new FileInfo(file);
                    }
                }
            }
        }
    }
}
