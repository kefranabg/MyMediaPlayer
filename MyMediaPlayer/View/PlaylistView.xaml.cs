﻿using MyMediaPlayer.Helper;
using MyMediaPlayer.Model;
using MyMediaPlayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyMediaPlayer.View
{
    public partial class PlaylistView : UserControl
    {
        public PlaylistView()
        {
            InitializeComponent();
        }

        private void MouseOver(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Hand;
            (sender as Button).Foreground = new SolidColorBrush(Colors.White);
        }

        private void MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Arrow;
            (sender as Button).Foreground = new SolidColorBrush(Color.FromRgb(167, 170, 172));
        }
		
		private void buttonOver(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Hand;
            (sender as Grid).Background = new SolidColorBrush(Color.FromRgb(34, 86, 148));
        }

        private void buttonLeave(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Arrow;
            (sender as Grid).Background = new SolidColorBrush(Color.FromRgb(31, 55, 95));
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.DataContext == null)
                return;
            var dataContext = this.DataContext as PlaylistViewModel;
            PlaylistModel selectedPlaylist = (PlaylistModel)this.listPlaylist.SelectedItem;
            dataContext.selectedPlaylist = selectedPlaylist;
            if (selectedPlaylist != null)
                ObservableCollectionHelpers.Replace(dataContext.currentPlaylist, selectedPlaylist.ListMedias);
        }

        private void listMedias_Drop(object sender, DragEventArgs e)
        {
            string[] filePaths = e.Data.GetData(DataFormats.FileDrop, true) as string[];
            ((PlaylistViewModel)this.DataContext).InsertFileListToPlaylist(filePaths);
        }

    }
}
