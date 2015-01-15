using MyMediaPlayer.Helper;
using MyMediaPlayer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMediaPlayer.ViewModel
{
    public class LibraryViewModel : BaseViewModel
    {
        public enum FolderType { Video, Music, Picture };
        public ObservableCollection<MediaModel> musicFolder { get; set; }
        public ObservableCollection<MediaModel> pictureFolder { get; set; }
        public ObservableCollection<MediaModel> videoFolder { get; set; }
        public ObservableCollection<MediaModel> currentFolder { get; set; }
        public RelayCommand ChangeFolderCommand { get; set; }

        public void ChangeFolder(object param)
        {
            if (FolderType.Video == (FolderType)param)
                ObservableCollectionHelpers.Replace(this.currentFolder, this.videoFolder);
            else if (FolderType.Music == (FolderType)param)
                ObservableCollectionHelpers.Replace(this.currentFolder, this.musicFolder);
            else
                ObservableCollectionHelpers.Replace(this.currentFolder, this.pictureFolder);
        }
        
        private void ScanFolders()
        {
            // Scan Music folder and add musics files to list
            string pathFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            foreach (string file in Directory.EnumerateFiles(pathFolder)
            .Where(s => s.EndsWith(".mp3") || s.EndsWith(".flac") || s.EndsWith(".cda") || s.EndsWith(".wpl")
             || s.EndsWith(".wav") || s.EndsWith(".aac") || s.EndsWith(".ogg")
              || s.EndsWith(".wma") || s.EndsWith(".mid") || s.EndsWith(".ra")))
                musicFolder.Add(new MediaModel(new Uri(file), Path.GetFileNameWithoutExtension(file)));

            // Scan Picture folder and add pictures files to list
            pathFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            foreach (string file in Directory.EnumerateFiles(pathFolder)
            .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".bmp") || s.EndsWith(".gif")))
                pictureFolder.Add(new MediaModel(new Uri(file), Path.GetFileNameWithoutExtension(file)));
            
            // Scan Video folder and add videos files to list
            pathFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            foreach (string file in Directory.EnumerateFiles(pathFolder)
                .Where(s => s.EndsWith(".mpg") || s.EndsWith(".mpeg") || s.EndsWith(".mp4") || s.EndsWith(".avi") || s.EndsWith(".mpeg")))
                videoFolder.Add(new MediaModel(new Uri(file), Path.GetFileNameWithoutExtension(file)));           
        }

        public LibraryViewModel()
        {
            musicFolder = new ObservableCollection<MediaModel>();
            pictureFolder = new ObservableCollection<MediaModel>();
            videoFolder = new ObservableCollection<MediaModel>();
            currentFolder = new ObservableCollection<MediaModel>();
            ChangeFolderCommand = new RelayCommand(ChangeFolder);
            ScanFolders();
            ObservableCollectionHelpers.Replace(this.currentFolder, this.videoFolder);
        }
    }
}
