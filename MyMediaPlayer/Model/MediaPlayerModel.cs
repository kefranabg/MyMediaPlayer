using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyMediaPlayer.Model
{
    public class MediaPlayerModel : BaseModel
    {
        private Uri source;
        public Uri Source
        {
            get { return source; }
            set
            {
                source = value;
                RaisePropertyChanged("Source");
            }
        }

        private bool isPlaying;
        public bool IsPlaying
        {
            get { return isPlaying; }
            set
            {
                isPlaying = value;
                RaisePropertyChanged("IsPlaying");
            }
        }

        private double volume;
        public double Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                RaisePropertyChanged("Volume");
            }
        }

        private double positionTime;
        public double PositionTime
        {
            get { return positionTime; }
            set
            {
                positionTime = value;
                RaisePropertyChanged("PositionTime");
            }
        }

        private double totalTime;
        public double TotalTime
        {
            get { return totalTime; }
            set
            {
                totalTime = value;
                RaisePropertyChanged("TotalTime");
            }
        }

        private bool isMute;

        public bool IsMute
        {
            get { return isMute; }
            set
            {
                isMute = value;
                RaisePropertyChanged("IsMute");
            }
        }
    }
}
