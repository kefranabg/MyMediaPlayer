using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMediaPlayer.Model
{
    public class MediaModel : BaseModel
    {

        public MediaModel(Uri _path, string _title)
        {
            this.Path = _path;
            this.Title = _title;
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
    }
}
