﻿#pragma checksum "..\..\..\View\MediaPlayerView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "695EB1D719C894B4F71B210B2546A11A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MyMediaPlayer.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MyMediaPlayer.View {
    
    
    /// <summary>
    /// MediaPlayerView
    /// </summary>
    public partial class MediaPlayerView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\View\MediaPlayerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyMediaPlayer.View.MediaPlayerView mediaPlayerUserControl;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\View\MediaPlayerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement myMediaElem;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\View\MediaPlayerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider timelineSlider;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MyMediaPlayer;component/view/mediaplayerview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\MediaPlayerView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.mediaPlayerUserControl = ((MyMediaPlayer.View.MediaPlayerView)(target));
            return;
            case 2:
            
            #line 11 "..\..\..\View\MediaPlayerView.xaml"
            ((System.Windows.Controls.Grid)(target)).Drop += new System.Windows.DragEventHandler(this.Grid_Drop);
            
            #line default
            #line hidden
            return;
            case 3:
            this.myMediaElem = ((System.Windows.Controls.MediaElement)(target));
            
            #line 14 "..\..\..\View\MediaPlayerView.xaml"
            this.myMediaElem.MediaOpened += new System.Windows.RoutedEventHandler(this.Element_MediaOpened);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\View\MediaPlayerView.xaml"
            this.myMediaElem.MediaEnded += new System.Windows.RoutedEventHandler(this.Element_MediaEnded);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 16 "..\..\..\View\MediaPlayerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LoadEvents);
            
            #line default
            #line hidden
            return;
            case 5:
            this.timelineSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 20 "..\..\..\View\MediaPlayerView.xaml"
            this.timelineSlider.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.SeekToMediaPosition);
            
            #line default
            #line hidden
            
            #line 21 "..\..\..\View\MediaPlayerView.xaml"
            this.timelineSlider.AddHandler(System.Windows.Controls.Primitives.Thumb.DragStartedEvent, new System.Windows.Controls.Primitives.DragStartedEventHandler(this.DragStart));
            
            #line default
            #line hidden
            
            #line 21 "..\..\..\View\MediaPlayerView.xaml"
            this.timelineSlider.AddHandler(System.Windows.Controls.Primitives.Thumb.DragCompletedEvent, new System.Windows.Controls.Primitives.DragCompletedEventHandler(this.DragEnd));
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 23 "..\..\..\View\MediaPlayerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LoadEvents);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 26 "..\..\..\View\MediaPlayerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LoadEvents);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 29 "..\..\..\View\MediaPlayerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LoadEvents);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 30 "..\..\..\View\MediaPlayerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LoadEvents);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 34 "..\..\..\View\MediaPlayerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MuteUnmute);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

