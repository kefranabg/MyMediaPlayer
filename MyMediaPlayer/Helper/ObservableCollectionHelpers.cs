using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMediaPlayer.Helper
{
    public static class ObservableCollectionHelpers
    {
        public static void Replace<T>(this ObservableCollection<T> old, ObservableCollection<T> tmp)
        {
            old.Clear();
            foreach (var item in tmp)
                old.Add(item);
        }
    }
}
