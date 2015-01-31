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
        public FolderType actualType;
        public ObservableCollection<MediaModel> musicFolder { get; set; }
        public ObservableCollection<MediaModel> pictureFolder { get; set; }
        public ObservableCollection<MediaModel> videoFolder { get; set; }
        public ObservableCollection<MediaModel> currentFolder { get; set; }
        public RelayCommand ChangeFolderCommand { get; set; }
        public RelayCommand SortByTitleCommand { get; set; }
        public RelayCommand SortByDurationCommand { get; set; }
        public RelayCommand SortByGenresCommand { get; set; }
        public RelayCommand SortByAlbumCommand { get; set; }
        public RelayCommand SortByArtistsCommand { get; set; }

        private String searchText;
        public String SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                RaisePropertyChanged("SearchText");
                this.SortBySearch();
            }
        }

        public void ChangeFolder(object param)
        {
            if (FolderType.Video == (FolderType)param)
                ObservableCollectionHelpers.Replace(this.currentFolder, this.videoFolder);
            else if (FolderType.Music == (FolderType)param)
                ObservableCollectionHelpers.Replace(this.currentFolder, this.musicFolder);
            else
                ObservableCollectionHelpers.Replace(this.currentFolder, this.pictureFolder);
            actualType = (FolderType)param;
        }

        public void FillMediaInfos(MediaModel media, String path)
        {
            media.Title = Path.GetFileNameWithoutExtension(path);
            media.Duration = MediaInfo.getDuration(path);
            media.Album = MediaInfo.getAlbum(path);
            String[] List = MediaInfo.getGenres(path);
            if (List != null)
                foreach (String Genre in List)
                    media.Genres += Genre;
            List = MediaInfo.getArtists(path);
            if (List != null)
                foreach (String Artist in List)
                    media.Artists += Artist;
        }

        private void ScanFolders()
        {
            // Scan Music folder and add musics files to list
            string pathFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            foreach (string file in Directory.EnumerateFiles(pathFolder)
            .Where(s => s.EndsWith(".mp3") || s.EndsWith(".flac") || s.EndsWith(".cda") || s.EndsWith(".wpl")
             || s.EndsWith(".wav") || s.EndsWith(".aac") || s.EndsWith(".ogg")
              || s.EndsWith(".wma") || s.EndsWith(".mid") || s.EndsWith(".ra")))
            {
                MediaModel newMedia = new MediaModel(new Uri(file));
                this.FillMediaInfos(newMedia, file);
                musicFolder.Add(newMedia);
            }
                
            // Scan Picture folder and add pictures files to list
            pathFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            foreach (string file in Directory.EnumerateFiles(pathFolder)
            .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".bmp") || s.EndsWith(".gif")))
            {
                MediaModel newMedia = new MediaModel(new Uri(file));
                newMedia.Title = Path.GetFileNameWithoutExtension(file);
                pictureFolder.Add(newMedia);
            }
                
            // Scan Video folder and add videos files to list
            pathFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            foreach (string file in Directory.EnumerateFiles(pathFolder)
                .Where(s => s.EndsWith(".mpg") || s.EndsWith(".mpeg") || s.EndsWith(".mp4") || s.EndsWith(".avi") || s.EndsWith(".mpeg")))
            {
                MediaModel newMedia = new MediaModel(new Uri(file));
                this.FillMediaInfos(newMedia, file);
                videoFolder.Add(newMedia);
            }           
        }

        public void SortBySearch()
        {
            List<MediaModel> tmp = new List<MediaModel>();
            ObservableCollection<MediaModel> toCompare;
            if (actualType == FolderType.Video)
                toCompare = videoFolder;
            else if (actualType == FolderType.Music)
                toCompare = musicFolder;
            else
                toCompare = pictureFolder;
            foreach (MediaModel media in toCompare)
                if (media.Title != null && media.Title.Contains(SearchText))
                    tmp.Add(media);
            this.currentFolder.Clear();
            foreach (MediaModel elem in tmp)
                this.currentFolder.Add(elem);
        }

        public void SortByTitle(object param)
        {
            List<MediaModel> tmp = new List<MediaModel>();
            var request = from elem in this.currentFolder orderby elem.Title select elem;
            foreach (MediaModel elem in request)
                tmp.Add(elem);
            this.currentFolder.Clear();
            foreach (MediaModel elem in tmp)
                this.currentFolder.Add(elem);
        }

        public void SortByGenres(object param)
        {
            List<MediaModel> tmp = new List<MediaModel>();
            var request = from elem in this.currentFolder orderby elem.Genres select elem;
            foreach (MediaModel elem in request)
                tmp.Add(elem);
            this.currentFolder.Clear();
            foreach (MediaModel elem in tmp)
                this.currentFolder.Add(elem);
        }

        public void SortByAlbum(object param)
        {
            List<MediaModel> tmp = new List<MediaModel>();
            var request = from elem in this.currentFolder orderby elem.Album select elem;
            foreach (MediaModel elem in request)
                tmp.Add(elem);
            this.currentFolder.Clear();
            foreach (MediaModel elem in tmp)
                this.currentFolder.Add(elem);
        }

        public void SortByArtists(object param)
        {
            List<MediaModel> tmp = new List<MediaModel>();
            var request = from elem in this.currentFolder orderby elem.Artists select elem;
            foreach (MediaModel elem in request)
                tmp.Add(elem);
            this.currentFolder.Clear();
            foreach (MediaModel elem in tmp)
                this.currentFolder.Add(elem);
        }

        public void SortByDuration(object param)
        {
            List<MediaModel> tmp = new List<MediaModel>();
            var request = from elem in this.currentFolder orderby elem.Duration select elem;
            foreach (MediaModel elem in request)
                tmp.Add(elem);
            this.currentFolder.Clear();
            foreach (MediaModel elem in tmp)
                this.currentFolder.Add(elem);
        }

        public LibraryViewModel()
        {
            actualType = FolderType.Video;
            musicFolder = new ObservableCollection<MediaModel>();
            pictureFolder = new ObservableCollection<MediaModel>();
            videoFolder = new ObservableCollection<MediaModel>();
            currentFolder = new ObservableCollection<MediaModel>();
            ChangeFolderCommand = new RelayCommand(ChangeFolder);
            SortByTitleCommand = new RelayCommand(SortByTitle);
            SortByDurationCommand = new RelayCommand(SortByDuration);
            SortByAlbumCommand = new RelayCommand(SortByAlbum);
            SortByArtistsCommand = new RelayCommand(SortByArtists);
            SortByGenresCommand = new RelayCommand(SortByGenres);
            ScanFolders();
            ObservableCollectionHelpers.Replace(this.currentFolder, this.videoFolder);
        }
    }
}
