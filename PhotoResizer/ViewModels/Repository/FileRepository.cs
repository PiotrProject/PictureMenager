using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Collections.ObjectModel;

namespace PhotoResizer.ViewModels.Repository
{
    public class FileRepository
    {
        public ObservableCollection<File> Files { get; set; }

        public FileRepository()
        {
            Files = new ObservableCollection<File>();
        }
        public void AddFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Files.Add(new File(openFileDialog.FileName, (FileStream)openFileDialog.OpenFile(), openFileDialog.OpenFile(), openFileDialog.SafeFileName));
            }
        }

        public void RemoveFile(string nameFile)
        {
            var file = Files.FirstOrDefault(x => x.FileName == nameFile);
            Files.Remove(file);
        }

        public void ClearAll()
        {
            Files.Clear();
        }

        public FileStream OpenFile(string nameFile)
        {
            return Files.FirstOrDefault(x => x.FileName == nameFile).FileStream;
        }

        public int CurrentIndex(string fileName)
        {
            var file = Files.FirstOrDefault(x => x.FileName == fileName);
            return Files.IndexOf(file);
        }
    }
}
