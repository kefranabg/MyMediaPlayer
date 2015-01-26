using Microsoft.Expression.Interactivity.Core;
using Microsoft.WindowsAPICodePack.Shell;
using MyMediaPlayer.Helper;
using MyMediaPlayer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyMediaPlayer.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        public enum ViewType { Library, MediaPlayer, Playlist }
        public RelayCommand switchViewCommand { get; set; }
        public RelayCommand switchPlaylistCommand { get; set; }

        private MediaPlayerViewModel mediaPlayerView = new MediaPlayerViewModel();

        private LibraryViewModel libraryView = new LibraryViewModel();

        private PlaylistViewModel playlistView = new PlaylistViewModel();

        private BaseViewModel currentView;
        public BaseViewModel CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                RaisePropertyChanged("CurrentView");
            }
        }

         public delegate void changeView();
         public MainWindowViewModel()
         {
             switchViewCommand = new RelayCommand(switchView);
             switchPlaylistCommand = new RelayCommand(switchPlaylist);
             this.CurrentView = mediaPlayerView;
         }

        public void switchView(object param)
         {
            if ((ViewType)param == ViewType.Library)
                this.CurrentView = libraryView;
            else if ((ViewType)param == ViewType.Playlist)
                this.CurrentView = playlistView;
            else
                this.CurrentView = mediaPlayerView; 
         }

        public void switchPlaylist(object param)
        {
            ObservableCollection<MediaModel> list = new ObservableCollection<MediaModel>();
            try { list = (ObservableCollection<MediaModel>)param; }
            catch (System.InvalidCastException e)
            {
                var items = (param as ObservableCollection<object>).Cast<MediaModel>().ToList();
                foreach (MediaModel elem in items)
                    list.Add(elem);
            }
            if (list.Count == 0)
                return;
            mediaPlayerView.replacePlaylist(list, 0);
            this.switchView(ViewType.MediaPlayer);
        }
    }
}
