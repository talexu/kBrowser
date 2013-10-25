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
        private KinectSensor _sensor;

        public MainWindow()
        {
            InitializeComponent();

            v_overall.DataContext = ViewModels.instance;

            RegisterView(ViewType.overall, v_overall);
            RegisterView(ViewType.picture, v_picture);

            //Commons.getNonKinectInitializer().run();
            //SoDictionary parameters = new SoDictionary(new object[] { Config.k_kinectRegion, kinectRegion, Config.k_kinectSensorChooserUI, sensorChooserUi, Config.k_sensor, _sensor });
            SoDictionary parameters = new SoDictionary(Config.k_kinectRegion, kinectRegion, Config.k_kinectSensorChooserUI, sensorChooserUi);
            Commons.getInitializer(parameters).run();
        }

        private void ControlsBasicsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            KinectCommands.stopKinect.Execute(null);
            KinectCommands.CloseWindow();  // Stop Audio
        }

        private void main_win_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void RegisterView(ViewType viewType, FrameworkElement view)
        {
            SoDictionary parameters = new SoDictionary(Config.k_viewType, viewType, Config.k_frameworkElement, view);
            ViewCommands.registerViewCommand.Execute(parameters);
        }
    }
}
