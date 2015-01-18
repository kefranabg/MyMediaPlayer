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

        public void AddPlaylist(object param)
        {
            if (this.PlaylistName != "")
                this.listPlaylist.Add(new PlaylistModel(this.PlaylistName, new ObservableCollection<MediaModel>()));
            this.PlaylistName = "";    
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
            {
                foreach (String file in dialog.FileNames)
                {
                    this.currentPlaylist.Add(new MediaModel(new Uri(file), Path.GetFileNameWithoutExtension(file)));
                    this.selectedPlaylist.ListMedias.Add(new MediaModel(new Uri(file), Path.GetFileNameWithoutExtension(file)));
                }
           }     
        }

        public void DeleteMedia(object param)
        {
            var items = (param as ObservableCollection<object>).Cast<MediaModel>().ToList();
            foreach (MediaModel elem in items)
                for (int i = 0; i < currentPlaylist.Count; i++)
                    if (currentPlaylist[i] == elem)
                        currentPlaylist.RemoveAt(i);
        }

        public void DeletePlaylist(object param)
        {
            var items = (param as ObservableCollection<object>).Cast<PlaylistModel>().ToList();
            foreach (PlaylistModel elem in items)
                for (int i = 0; i < listPlaylist.Count; i++)
                    if (listPlaylist[i] == elem)
                        listPlaylist.RemoveAt(i);
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
        }
    }
}
