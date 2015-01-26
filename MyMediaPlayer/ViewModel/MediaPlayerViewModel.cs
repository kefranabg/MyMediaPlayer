using Microsoft.Win32;
using MyMediaPlayer.Model;
using MyMediaPlayer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;

namespace MyMediaPlayer.ViewModel
{
    public class MediaPlayerViewModel : BaseViewModel
    {
        private MediaPlayerModel mediaPlayer = new MediaPlayerModel();
        private ObservableCollection<MediaModel> playlist = new ObservableCollection<MediaModel>();
        private int currentMedia;
        public ObservableCollection<MediaModel> Playlist { get { return playlist; } }
        public Uri SourceUri
        {
            get { return this.mediaPlayer.Source; }
            set
            {
                this.mediaPlayer.Source = value;
                RaisePropertyChanged("SourceUri");
            }
        }

        public String IsPlaying {
            get { return mediaPlayer.IsPlaying ? "../Img/pause.PNG" : "../Img/play.PNG"; }
            set
            {
                if (value == "PAUSE")
                    mediaPlayer.IsPlaying = true;
                else
                    mediaPlayer.IsPlaying = false;
                RaisePropertyChanged("IsPlaying");
            }
        }

        public String IsMute
        {
            get { return mediaPlayer.IsMute ? "../Img/unmute.PNG" : "../Img/mute.PNG"; }
        }

        public bool setIsMute
        {
            set
            {
                this.mediaPlayer.IsMute = value;
                RaisePropertyChanged("IsMute");
            }
        }

        public double Volume
        {
            get { return this.mediaPlayer.Volume; }
            set
            {
                this.mediaPlayer.Volume = value;
                RaisePropertyChanged("Volume");
            }
        }

        public string PositionTime
        {
            get
            {
                var time = TimeSpan.FromMilliseconds(this.mediaPlayer.PositionTime);
                return time.ToString(@"hh\:mm\:ss");
            }
        }

        public double setPositionTime
        {
            set
            {
                this.mediaPlayer.PositionTime = value;
                RaisePropertyChanged("PositionTime");
            }
        }

        public string TotalTime
        {
            get
            {
                var time = TimeSpan.FromMilliseconds(this.mediaPlayer.TotalTime);
                return time.ToString(@"hh\:mm\:ss");
            }
        }

        public double setTotalTime
        {
            set
            {
                this.mediaPlayer.TotalTime = value;
                RaisePropertyChanged("TotalTime");
            }
        }

        public event EventHandler PlayEvent;
        public event EventHandler PauseEvent;
        public event EventHandler StopEvent;

        public RelayCommand BrowseCommand { get; set; }
        public RelayCommand PlayPauseCommand { get; set; }
        public RelayCommand StopCommand { get; set; }
        public RelayCommand MuteUnmuteCommand { get; set; }
        public RelayCommand NextCommand { get; set; }
        public RelayCommand PreviousCommand { get; set; }
        void Browse(object param)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.AddExtension = true;
            dialog.DefaultExt = "*.*";
            dialog.Filter = "Media(*.*)|*.*";
            bool? dialogResult = dialog.ShowDialog();
            if (dialogResult.Value && dialogResult.HasValue)
            {
                this.playlist.Clear();
                this.playlist.Add(new MediaModel(new Uri(dialog.FileName), "browse"));
                this.currentMedia = 0;
                this.ChangeSource(this.playlist[this.currentMedia].Path);
            }
        }

        public void ChangeSource(Uri value)
        {
            this.SourceUri = value;
            this.Play();
        }

        public void PlayPause(object param)
        {
            if (mediaPlayer.IsPlaying == true)
                this.Pause();
            else
                this.Play();
        }

        public void Play()
        {
            if (this.SourceUri == null)
                return;
            this.IsPlaying = "PAUSE";
            this.PlayEvent(this, EventArgs.Empty);
        }

        public void Pause()
        {
            this.IsPlaying = "PLAY";
            this.PauseEvent(this, EventArgs.Empty);
        }

        public void Stop(object param)
        {
            this.IsPlaying = "PLAY";
            this.StopEvent(this, EventArgs.Empty);
        }
        public void MuteUnmute(object param)
        {
            this.setIsMute = (this.mediaPlayer.IsMute) ? false : true;
        }

        public void Next(object param)
        {
            this.currentMedia = (this.playlist.Count - 1 > this.currentMedia) ? this.currentMedia + 1 : 0;
            if (this.playlist.Count > 0)
                this.SourceUri = this.playlist[this.currentMedia].Path;
        }

        public void Previous(object param)
        {
            this.currentMedia = (this.currentMedia > 0) ? this.currentMedia - 1 : this.playlist.Count - 1;
            if (this.playlist.Count > 0)
                this.SourceUri = this.playlist[this.currentMedia].Path;
        }

        public void replacePlaylist(ObservableCollection<MediaModel> newPlaylist, int newCurrentMedia)
        {
            ObservableCollectionHelpers.Replace(this.playlist, newPlaylist);
            this.currentMedia = newCurrentMedia;
            this.SourceUri = this.playlist[this.currentMedia].Path;
            this.IsPlaying = "PLAY";
        }

        public MediaPlayerViewModel()
        {
            BrowseCommand = new RelayCommand(Browse);
            PlayPauseCommand = new RelayCommand(PlayPause);
            StopCommand = new RelayCommand(Stop);
            NextCommand = new RelayCommand(Next);
            PreviousCommand = new RelayCommand(Previous);
            MuteUnmuteCommand = new RelayCommand(MuteUnmute);
            this.Volume = 0.5;
        }
    }
}
