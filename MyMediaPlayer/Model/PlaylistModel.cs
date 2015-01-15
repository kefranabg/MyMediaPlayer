using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMediaPlayer.Model
{
    public class PlaylistModel : BaseModel
    {
        public PlaylistModel(string _name, ObservableCollection<MediaModel> _listMedias)
        {
            this.Name = _name;
            this.ListMedias = _listMedias;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        private ObservableCollection<MediaModel> listMedias;
        public ObservableCollection<MediaModel> ListMedias
        {
            get { return listMedias; }
            set
            {
                listMedias = value;
                RaisePropertyChanged("Name");
            }
        }
    }
}
