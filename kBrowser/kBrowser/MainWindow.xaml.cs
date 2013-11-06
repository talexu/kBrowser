using kBrowser.Businesses;
using kBrowser.Models.Entity;
using kBrowser.Models.View;
using kBrowser.Utilities;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.IO;
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

            v_overall.DataContext = ViewModels.instance;

            RegisterView(ViewType.overall, v_overall);
            RegisterView(ViewType.picture, v_picture);

            Commons.getInitializer().run();
        }

        private void ControlsBasicsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            KinectManager.Instance.Stop();
        }

        private void main_win_Loaded(object sender, RoutedEventArgs e)
        {
            KinectManager.Instance.InitializeCamera(kinectRegion, sensorChooserUi);
            SoundManager.Instance.init();
        }

        private void RegisterView(ViewType viewType, FrameworkElement view)
        {
            SoDictionary parameters = new SoDictionary(Config.k_viewType, viewType, Config.k_frameworkElement, view);
            ViewCommands.registerViewCommand.Execute(parameters);
        }
    }
}
