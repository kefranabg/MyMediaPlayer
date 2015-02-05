using Microsoft.Win32;
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
    public class PlaylistViewModel : BaseViewModel
    {
        public ObservableCollection<PlaylistModel> listPlaylist { get; set; }
        public ObservableCollection<MediaModel> currentPlaylist { get; set; }
        public PlaylistModel selectedPlaylist { get; set; }

        private string playlistName;
        public string PlaylistName
        {
            get { return playlistName; }
            set
            {
                playlistName = value;
                RaisePropertyChanged("PlaylistName");
            }
        }
        public RelayCommand AddPlaylistCommand { get; set; }
        public RelayCommand AddMediaCommand { get; set; }
        public RelayCommand DeleteMediaCommand { get; set; }
        public RelayCommand DeletePlaylistCommand { get; set; }
        public RelayCommand SortByTitleCommand { get; set; }
        public RelayCommand SortByDurationCommand { get; set; }
        public RelayCommand SortByGenresCommand { get; set; }
        public RelayCommand SortByAlbumCommand { get; set; }
        public RelayCommand SortByArtistsCommand { get; set; }

        public void AddPlaylist(object param)
        {
            if (this.PlaylistName != "")
                this.listPlaylist.Add(new PlaylistModel(this.PlaylistName, new ObservableCollection<MediaModel>()));
            this.PlaylistName = "";    
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

        public void InsertFileListToPlaylist(String[] files)
        {
            if (this.selectedPlaylist != null)
                foreach (String file in files)
                {
                    if (Directory.Exists(file) == false)
                    {
                        MediaModel newMedia = new MediaModel(new Uri(file));
                        this.FillMediaInfos(newMedia, file);
                        this.currentPlaylist.Add(newMedia);
                        this.selectedPlaylist.ListMedias.Add(newMedia);
                    }
                }
        }

        public void AddMedia(object param)
        {
            if (this.selectedPlaylist == null)
                return;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.AddExtension = true;
            dialog.Multiselect = true;
            dialog.DefaultExt = "*.*";
            dialog.Filter = "Media(*.*)|*.*";
            bool? dialogResult = dialog.ShowDialog();
            if (dialogResult.Value && dialogResult.HasValue)
                this.InsertFileListToPlaylist(dialog.FileNames);
        }

        public void DeleteMedia(object param)
        {
            var items = (param as ObservableCollection<object>).Cast<MediaModel>().ToList();
            foreach (MediaModel elem in items)
                for (int i = 0; i < currentPlaylist.Count; i++)
                    if (currentPlaylist[i] == elem)
                    {
                        this.selectedPlaylist.ListMedias.RemoveAt(i);
                        currentPlaylist.RemoveAt(i);
                    }
        }

        public void DeletePlaylist(object param)
        {
            var items = (param as ObservableCollection<object>).Cast<PlaylistModel>().ToList();
            foreach (PlaylistModel elem in items)
                for (int i = 0; i < listPlaylist.Count; i++)
                    if (listPlaylist[i] == elem)
                        listPlaylist.RemoveAt(i);
        }

        public void SortByTitle(object param)
        {
            List<MediaModel> tmp = new List<MediaModel>();
            var request = from elem in this.currentPlaylist orderby elem.Title select elem;
            foreach (MediaModel elem in request)
               tmp.Add(elem);
            this.currentPlaylist.Clear();
            foreach (MediaModel elem in tmp)
               this.currentPlaylist.Add(elem);
        }

        public void SortByGenres(object param)
        {
            List<MediaModel> tmp = new List<MediaModel>();
            var request = from elem in this.currentPlaylist orderby elem.Genres select elem;
            foreach (MediaModel elem in request)
                tmp.Add(elem);
            this.currentPlaylist.Clear();
            foreach (MediaModel elem in tmp)
                this.currentPlaylist.Add(elem);
        }

        public void SortByAlbum(object param)
        {
            List<MediaModel> tmp = new List<MediaModel>();
            var request = from elem in this.currentPlaylist orderby elem.Album select elem;
            foreach (MediaModel elem in request)
                tmp.Add(elem);
            this.currentPlaylist.Clear();
            foreach (MediaModel elem in tmp)
                this.currentPlaylist.Add(elem);
        }

        public void SortByArtists(object param)
        {
            List<MediaModel> tmp = new List<MediaModel>();
            var request = from elem in this.currentPlaylist orderby elem.Artists select elem;
            foreach (MediaModel elem in request)
                tmp.Add(elem);
            this.currentPlaylist.Clear();
            foreach (MediaModel elem in tmp)
                this.currentPlaylist.Add(elem);
        }

        public void SortByDuration(object param)
        {
            List<MediaModel> tmp = new List<MediaModel>();
            var request = from elem in this.currentPlaylist orderby elem.Duration select elem;
            foreach (MediaModel elem in request)
                tmp.Add(elem);
            this.currentPlaylist.Clear();
            foreach (MediaModel elem in tmp)
                this.currentPlaylist.Add(elem);
        }

        public PlaylistViewModel()
        {
            this.playlistName = "";
            this.listPlaylist = new ObservableCollection<PlaylistModel>();
            this.currentPlaylist = new ObservableCollection<MediaModel>();
            AddPlaylistCommand = new RelayCommand(AddPlaylist);
            AddMediaCommand = new RelayCommand(AddMedia);
            DeleteMediaCommand = new RelayCommand(DeleteMedia);
            DeletePlaylistCommand = new RelayCommand(DeletePlaylist);
            SortByTitleCommand = new RelayCommand(SortByTitle);
            SortByDurationCommand = new RelayCommand(SortByDuration);
            SortByAlbumCommand = new RelayCommand(SortByAlbum);
            SortByArtistsCommand = new RelayCommand(SortByArtists);
            SortByGenresCommand = new RelayCommand(SortByGenres);
        }
    }
}
