using kBrowser.Businesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kBrowser
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //KinectManager.instance.initialize(kinectRegion, sensorChooserUi);
            DataManager.instance.LoadDemo();
            v_overall.DataContext = DataManager.instance;
        }

        private void OverallView_Loaded(object sender, RoutedEventArgs e)
        {
            ViewManager.instance.RegisterView(BrowserView.overall, sender as FrameworkElement);
        }

        private void PictureView_Loaded(object sender, RoutedEventArgs e)
        {
            ViewManager.instance.RegisterView(BrowserView.picture, sender as FrameworkElement);
        }

        private void ControlsBasicsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            KinectManager.instance.StopKinect();
        }
    }
}
