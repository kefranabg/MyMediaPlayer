using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Diagnostics;
using System.IO;
using TagLib;
using System.Windows.Media.Imaging;

namespace MyMediaPlayer.Helper
{
    public class MediaInfo
    {
        public static String getDuration(String filepath)
        {
            try {
                TagLib.File file = TagLib.File.Create(filepath);
                return new DateTime(file.Properties.Duration.Ticks).ToString("mm:ss");
            }
            catch (TagLib.UnsupportedFormatException e) {
                return null;
            }
        }

        public static String getAlbum(String filepath)
        {
            try {
                TagLib.File file = TagLib.File.Create(filepath);
                return file.Tag.Album;
            }
            catch (TagLib.UnsupportedFormatException e) {
                return null;
            }
        }

        public static String[] getArtists(String filepath)
        {
            try {
                TagLib.File file = TagLib.File.Create(filepath);
                return file.Tag.AlbumArtists;
            }
            catch (TagLib.UnsupportedFormatException e) {
                return null;
            }
        }

        public static String getCopyrigth(String filepath)
        {
            try {
                TagLib.File file = TagLib.File.Create(filepath);
                return file.Tag.Copyright;
            }
            catch (TagLib.UnsupportedFormatException e) {
                return null;
            }
        }

        public static String[] getGenres(String filepath)
        {
            try {
                TagLib.File file = TagLib.File.Create(filepath);
                return file.Tag.Genres;
            }
            catch (TagLib.UnsupportedFormatException e) {
                return null;
            }
        }

        public static BitmapImage getPictures(String filepath)
        {
            TagLib.File file = TagLib.File.Create(filepath);
            TagLib.IPicture pic = file.Tag.Pictures[0];
            MemoryStream ms = new MemoryStream(pic.Data.Data);
            ms.Seek(0, SeekOrigin.Begin);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = ms;
            bitmap.EndInit();
            return bitmap;
        }

        public static String getTitle(String filepath)
        {
            try {
                TagLib.File file = TagLib.File.Create(filepath);
                return file.Tag.Title;
            }
            catch (TagLib.UnsupportedFormatException e) {
                return null;
            }
        }

        public static int getYear(String filepath)
        {
            try
            {
                TagLib.File file = TagLib.File.Create(filepath);
                return (int)file.Tag.Year;
            }
            catch (TagLib.UnsupportedFormatException e) {
                return (0);
            }
        }

    }

}