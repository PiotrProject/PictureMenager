using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PhotoResizer.ViewModels.Repository
{
    public class File
    {
        public string FileName { get; private set; }
        public FileStream FileStream { get; set; }
        public Stream Mini { get; set; }
        public string FileNameFull { get; set; }

        public File(string fileName, FileStream fileStream ,Stream mini, string fileNameFull)
        {
            FileName = fileName;
            FileStream = fileStream;
            Mini = mini;
            FileNameFull = fileNameFull;
        }
    }
}
