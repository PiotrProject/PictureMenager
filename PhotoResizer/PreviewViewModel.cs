using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PhotoResizer.ViewModels;
using PhotoResizer.ViewModels.Commands;
using PhotoResizer.ViewModels.Repository;

namespace PhotoResizer
{
    public class PreviewViewModel : INotifyPropertyChanged
    {
        public FileRepository Files { get; set; }
        public Command NextFileCommand { get; private set; }
        public Command PreviousFileCommand { get; private set; }

        private ImageSource _currentImage;
        public ImageSource CurrentImage { 
            get {
                return _currentImage;
            }
            set { 
                if (_currentImage != value)
                {
                    _currentImage = value;
                    OnPropertyChanged();
                }
            } 
        }
        public int CurrentIndex { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PreviewViewModel(FileRepository Repository)
        {
            NextFileCommand = new Command(NextFile);
            PreviousFileCommand = new Command(PreviousFile);
            Files = Repository;
        }

        public void NextFile()
        {
            if (CurrentIndex < Files.Files.Count-1)
                CurrentIndex += 1;
            CurrentImage = Api.BitmapFromUri(new Uri(Files.Files[CurrentIndex].FileName));
        }

        public void PreviousFile()
        {
            if(CurrentIndex > 0)
                CurrentIndex -= 1;
            CurrentImage = Api.BitmapFromUri(new Uri(Files.Files[CurrentIndex].FileName));
        }

    }
}
