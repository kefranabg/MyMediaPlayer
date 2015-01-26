using MyMediaPlayer.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MyMediaPlayer.View
{
    public partial class MediaPlayerView : UserControl
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private bool isDragging = false;

        void ticks(object sender, EventArgs e)
        {
            if (isDragging == false)
                this.timelineSlider.Value = this.myMediaElem.Position.TotalMilliseconds;
        }

        private void LoadEvents(object sender, RoutedEventArgs e)
        {
            var dataContext = myMediaElem.DataContext as MediaPlayerViewModel;
            dataContext.PlayEvent += (_sender, _e) => {
                this.myMediaElem.Play();
                this.timer.Start();
            };
            dataContext.PauseEvent += (_sender, _e) => { this.myMediaElem.Pause(); this.timer.Stop(); };
            dataContext.StopEvent += (_sender, _e) => { this.myMediaElem.Stop(); };
        }

        private void Element_MediaOpened(object sender, EventArgs e)
        {
            if (this.myMediaElem.NaturalDuration.HasTimeSpan)
                this.timelineSlider.Maximum = myMediaElem.NaturalDuration.TimeSpan.TotalMilliseconds; 
            else
                this.timelineSlider.Maximum = 0;
        }

        private void Element_MediaEnded(object sender, EventArgs e)
        {
            ((MediaPlayerViewModel)this.DataContext).Next(EventArgs.Empty);
        }

        private void SeekToMediaPosition(object sender, MouseButtonEventArgs e)
        {
                myMediaElem.Position = TimeSpan.FromMilliseconds(timelineSlider.Value);
                this.isDragging = false;
        }

        private void DragStart(object sender, DragStartedEventArgs e)
        {
            this.isDragging = true;
            this.myMediaElem.Pause();
        }

        private void DragEnd(object sender, DragCompletedEventArgs e)
        {
            this.isDragging = false;
            myMediaElem.Position = TimeSpan.FromMilliseconds(timelineSlider.Value);
            this.myMediaElem.Play();
        }

        public MediaPlayerView()
        {
            InitializeComponent();
            this.timer.Interval = TimeSpan.FromMilliseconds(1000);
            this.timer.Tick += new EventHandler(ticks);
        }

        private void MuteUnmute(object sender, RoutedEventArgs e)
        {
            this.myMediaElem.IsMuted = (this.myMediaElem.IsMuted) ? false : true;
        }

        private void Grid_Drop(object sender, DragEventArgs e)
        {
            //this is the droped playlist
            string[] filePaths = e.Data.GetData(DataFormats.FileDrop, true) as string[];
            
            //playing first element in the playlist
            this.myMediaElem.Source = new Uri(filePaths[0]);
            this.myMediaElem.Play();
        }
    }
}
