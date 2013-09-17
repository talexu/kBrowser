using kBrowser.Businesses;
using kBrowser.Utilities;
using System;
using System.Collections.Generic;
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

namespace kBrowser.Views
{
    /// <summary>
    /// OverallView.xaml 的交互逻辑
    /// </summary>
    public partial class OverallView : UserControl
    {
        public OverallView()
        {
            InitializeComponent();
        }

        private void kic_pictures_ItemClick(object sender, RoutedEventArgs e)
        {
            Microsoft.Kinect.Toolkit.Controls.KinectTileButton ktb = TypeHelper.ToType<Microsoft.Kinect.Toolkit.Controls.KinectTileButton>(e.OriginalSource);
            if (ktb != null)
            {
                CommandsManager.jumpToPictureViewCommand.Execute(ktb.DataContext);
            }
        }
    }
}
