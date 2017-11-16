using FStvol.Droid.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace FStvol.Droid.Test.Tests
{
    public class AndroidFileSystemServiceTest : IDisposable
    {
        private string somethingPath;

        public AndroidFileSystemServiceTest()
        {
            var service = new AndroidFileSystemService();
            var aFolder = service.SearchFolders.First();

            somethingPath = System.IO.Path.Combine(aFolder, "something.tvol");

            System.IO.File.Create(somethingPath);
        }

        public void Dispose()
        {
            if(System.IO.File.Exists(somethingPath))
            {
                System.IO.File.Delete(somethingPath);
            }
        }

        [Fact]
        public void GetFilesTest()
        {
            var service = new AndroidFileSystemService();

            IEnumerable<System.IO.FileInfo> files = null;
            service.Invoking(x => files = x.GetFiles()).ShouldNotThrow();

            files.Should().HaveCount(1);
            
        }

        [Fact]
        public void SearchFoldersTest()
        {
            var service = new AndroidFileSystemService();


            var result = service.SearchFolders.ToList();
            result.Should().HaveCount(2);

            result.Should().OnlyContain(x => System.IO.Directory.Exists(x));
        }

    }
}
