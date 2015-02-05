using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
namespace MyMediaPlayer.Model
{
    public class PlaylistModel : BaseModel
    {

        public PlaylistModel()
        {
            this.Name = "None";
            this.ListMedias = new ObservableCollection<MediaModel>();
        }
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

        public PlaylistModelSerializer getSerializer()
        {
            PlaylistModelSerializer ret = new PlaylistModelSerializer();
            ret.Name = this.name;
            foreach (MediaModel mm in listMedias)
            {
                ret.media.Add(mm.getSerializer());
            }
            return ret;
        }
    }
    [Serializable]
    public class PlaylistModelSerializer
    {
        public PlaylistModelSerializer()
        {
            this.Name = "";
            this.media = new Collection<MediaModelSerializer>();
        }
        public string Name { get; set; }
        [XmlArray]
        public Collection<MediaModelSerializer> media { get; set; }
        public PlaylistModel getDeSerializer()
        {
            PlaylistModel ret = new PlaylistModel();
            ret.Name = this.Name;
            foreach (MediaModelSerializer mms in media)
            {
                ret.ListMedias.Add(mms.getDeSerializer());
            }
            return ret;

        }
    }

}
