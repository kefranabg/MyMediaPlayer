﻿#pragma checksum "..\..\..\View\MediaPlayerView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "44AC778577EFDD7D0861AB8EF4FE56C2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18444
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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
        
        
        #line 58 "..\..\..\View\MediaPlayerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider timelineSlider;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\View\MediaPlayerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement myMediaElem;
        
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
            
            #line 8 "..\..\..\View\MediaPlayerView.xaml"
            ((System.Windows.Controls.Grid)(target)).Drop += new System.Windows.DragEventHandler(this.Grid_Drop);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 32 "..\..\..\View\MediaPlayerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LoadEvents);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 35 "..\..\..\View\MediaPlayerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LoadEvents);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 38 "..\..\..\View\MediaPlayerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LoadEvents);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 41 "..\..\..\View\MediaPlayerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LoadEvents);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 42 "..\..\..\View\MediaPlayerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LoadEvents);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 46 "..\..\..\View\MediaPlayerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MuteUnmute);
            
            #line default
            #line hidden
            return;
            case 9:
            this.timelineSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 59 "..\..\..\View\MediaPlayerView.xaml"
            this.timelineSlider.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.SeekToMediaPosition);
            
            #line default
            #line hidden
            
            #line 60 "..\..\..\View\MediaPlayerView.xaml"
            this.timelineSlider.AddHandler(System.Windows.Controls.Primitives.Thumb.DragStartedEvent, new System.Windows.Controls.Primitives.DragStartedEventHandler(this.DragStart));
            
            #line default
            #line hidden
            
            #line 60 "..\..\..\View\MediaPlayerView.xaml"
            this.timelineSlider.AddHandler(System.Windows.Controls.Primitives.Thumb.DragCompletedEvent, new System.Windows.Controls.Primitives.DragCompletedEventHandler(this.DragEnd));
            
            #line default
            #line hidden
            return;
            case 10:
            this.myMediaElem = ((System.Windows.Controls.MediaElement)(target));
            
            #line 65 "..\..\..\View\MediaPlayerView.xaml"
            this.myMediaElem.MediaOpened += new System.Windows.RoutedEventHandler(this.Element_MediaOpened);
            
            #line default
            #line hidden
            
            #line 65 "..\..\..\View\MediaPlayerView.xaml"
            this.myMediaElem.MediaEnded += new System.Windows.RoutedEventHandler(this.Element_MediaEnded);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

