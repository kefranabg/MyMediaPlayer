using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMediaPlayer.Model
{
    public class MediaModel : BaseModel
    {

        public MediaModel(Uri _path)
        {
            this.Path = _path;
        }

        private Uri path;
        public Uri Path
        {
            get { return path; }
            set
            {
                path = value;
                RaisePropertyChanged("Path");
            }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged("Title");
            }
        }

        private string duration;
        public string Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                RaisePropertyChanged("Duration");
            }
        }

        private string album;
        public string Album
        {
            get { return album; }
            set
            {
                album = value;
                RaisePropertyChanged("Album");
            }
        }

        private string genres;
        public string Genres
        {
            get { return genres; }
            set
            {
                genres = value;
                RaisePropertyChanged("Genres");
            }
        }

        private string artists;
        public string Artists
        {
            get { return artists; }
            set
            {
                artists = value;
                RaisePropertyChanged("Artists");
            }
        }
    }
}
