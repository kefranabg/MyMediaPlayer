using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
namespace MyMediaPlayer.Model
{
    public class MediaModel : BaseModel
    {
        public MediaModel()
        {
            this.Path = null;
        }

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

        public MediaModelSerializer getSerializer()
        {
            MediaModelSerializer ret = new MediaModelSerializer();

            ret.album = this.album;
            ret.artists = this.artists;
            ret.duration = this.duration;
            ret.path = this.path.ToString();
            ret.title = this.title;
            ret.genres = this.genres;
            return ret;
        }
    }
    [Serializable]
    public class MediaModelSerializer
    {
        public MediaModelSerializer()
        {
            this.path = "";
            this.title = "";
            this.duration = "";
            this.album = "";
            this.genres = "";
            this.artists = "";
        }
        public string path { get; set; }
        public string title { get; set; }
        public string duration { get; set; }
        public string album { get; set; }
        public string genres { get; set; }
        public string artists { get; set; }
        public MediaModel getDeSerializer()
        {
            MediaModel ret = new MediaModel();

            ret.Album = this.album;
            ret.Artists = this.artists;
            ret.Duration = this.duration;
            ret.Path = new Uri(this.path);
            ret.Title = this.title;
            ret.Genres = this.genres;
            return ret;
        }
    }
}
