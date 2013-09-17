using kBrowser.Businesses;
using kBrowser.Models.View;
using kBrowser.Utilities;
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

            v_overall.DataContext = ViewModels.instance;

            ViewCommands.registerViewCommand.Execute(new Tuple<ViewType, FrameworkElement>(ViewType.overall, TypeHelper.ToType<FrameworkElement>(v_overall)));
            ViewCommands.registerViewCommand.Execute(new Tuple<ViewType, FrameworkElement>(ViewType.picture, TypeHelper.ToType<FrameworkElement>(v_picture)));
        }

        private void ControlsBasicsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Initializations.stopKinect.Execute(null);
        }

        private void main_win_Loaded(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread th = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
                {
                    Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.SystemIdle, new Action(() =>
                        {
                            IDictionary<string, object> parameters = new Dictionary<string, object>();
                            parameters.Add("kinectRegion", kinectRegion);
                            parameters.Add("sensorChooserUi", sensorChooserUi);
                            Initializations.Initialize(parameters);
                        }));
                }));
            th.Start();
        }
    }
}
