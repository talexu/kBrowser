using kBrowser.Businesses;
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
    /// PictureView.xaml 的交互逻辑
    /// </summary>
    public partial class PictureView : UserControl
    {
        public PictureView()
        {
            InitializeComponent();

            SoundManager.Instance.ScaleChanged += Instance_ScaleChanged;
        }

        void Instance_ScaleChanged(float obj)
        {
            if (this.IsVisible)
            {
                double v = Math.Min(this.sl_scale.Value * obj, this.sl_scale.Maximum);
                v = Math.Max(v, this.sl_scale.Minimum);
                this.sl_scale.Value = v;
            }
        }
    }
}
