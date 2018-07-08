using Awesomium.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NotWorks
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
            if (!WebCore.IsInitialized)
            {
                WebCore.Initialize(new WebConfig()
                {
                    //HomeURL = new Uri(BaseAddress),
                    LogPath = @".\starter.log",
                    LogLevel = LogLevel.Verbose
                });
            }
            InitializeComponent();
        }


        #region webborrow

        // This will be set to the target URL, when this window does not
        // host a created child view. The WebControl, is bound to this property.
        public Uri Source
        {
            get { return (Uri)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        // Identifies the <see cref="Source"/> dependency property.
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source",
            typeof(Uri), typeof(MainWindow),
            new FrameworkPropertyMetadata(null));


        // This will be set to the created child view that the WebControl will wrap,
        // when ShowCreatedWebView is the result of 'window.open'. The WebControl, 
        // is bound to this property.
        public IntPtr NativeView
        {
            get { return (IntPtr)GetValue(NativeViewProperty); }
            private set { this.SetValue(MainWindow.NativeViewPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey NativeViewPropertyKey =
            DependencyProperty.RegisterReadOnly("NativeView",
            typeof(IntPtr), typeof(MainWindow),
            new FrameworkPropertyMetadata(IntPtr.Zero));

        // Identifies the <see cref="NativeView"/> dependency property.
        public static readonly DependencyProperty NativeViewProperty =
            NativeViewPropertyKey.DependencyProperty;

        // The visibility of the address bar and status bar, depends
        // on the value of this property. We set this to false when
        // the window wraps a WebControl that is the result of JavaScript
        // 'window.open'.
        public bool IsRegularWindow
        {
            get { return (bool)GetValue(IsRegularWindowProperty); }
            private set { this.SetValue(MainWindow.IsRegularWindowPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey IsRegularWindowPropertyKey =
            DependencyProperty.RegisterReadOnly("IsRegularWindow",
            typeof(bool), typeof(MainWindow),
            new FrameworkPropertyMetadata(true));

        // Identifies the <see cref="IsRegularWindow"/> dependency property.
        public static readonly DependencyProperty IsRegularWindowProperty =
            IsRegularWindowPropertyKey.DependencyProperty;


        private void webControl_WindowClose(object sender, WindowCloseEventArgs e)
        {
            // The page called 'window.close'. If the call
            // comes from a frame, ignore it.
            if (!e.IsCalledFromFrame)
                this.Close();
        }

        #endregion
    }
}
