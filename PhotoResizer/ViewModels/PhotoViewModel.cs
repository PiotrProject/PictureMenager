using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PhotoResizer.ViewModels.Commands;
using PhotoResizer.ViewModels.Repository;

namespace PhotoResizer.ViewModels
{
    public class PhotoViewModel
    {
        public Command AddFileCommand { get; private set; }
        public ParameterCommand OpenFileCommand { get; private set; }
        public ParameterCommand RemoveFileCommand { get; private set; }
        public Command ClearFileCommand { get; private set; }
        public List<Component> ImageComponent { get; private set; }
        public FileRepository Files { get; set; }

        public PhotoViewModel()
        {
            AddFileCommand = new Command(AddFile);
            OpenFileCommand = new ParameterCommand(OpenFile, isOpenFile);
            RemoveFileCommand = new ParameterCommand(RemoveFile, isOpenFile);
            ClearFileCommand = new Command(ClearFiles);
            ImageComponent = new List<Component>();
            Files = new FileRepository();
        }

        public void ClearFiles()
        {
            Files.ClearAll();
        }
        public void AddFile()
        {
            Files.AddFile();
        }

        public void RemoveFile(object FileName)
        {
            Files.RemoveFile((string)FileName);
        }
        public void OpenFile(object FileName)
        {
            ViewImage viewImage = new ViewImage();
            PreviewViewModel previousViewmodel = new PreviewViewModel(Files);
            viewImage.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            previousViewmodel.CurrentImage = Api.BitmapFromUri(new Uri(FileName.ToString()));
            previousViewmodel.CurrentIndex = Files.CurrentIndex((string)FileName);
            viewImage.DataContext = previousViewmodel;
            viewImage.ImageView.Source = previousViewmodel.CurrentImage;
            viewImage.Show();
        }

        public bool isOpenFile(object FileName)
        {
            if((string)FileName != null)
            {
                return true;
            }
            return false;
        }
    }
}
