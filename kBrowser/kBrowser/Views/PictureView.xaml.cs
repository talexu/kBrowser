using kBrowser.Businesses;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public Boolean IsSoundable
        {
            get { return (Boolean)this.GetValue(IsSoundableProperty); }
            set { this.SetValue(IsSoundableProperty, value); }
        }
        public static readonly DependencyProperty IsSoundableProperty = DependencyProperty.Register(
          "IsSoundable", typeof(Boolean), typeof(PictureView), new PropertyMetadata(false));

        public PictureView()
        {
            InitializeComponent();

            SoundManager.Instance.ScaleChanged += Instance_ScaleChanged;
        }

        void Instance_ScaleChanged(float obj)
        {
            if (this.IsVisible && this.IsSoundable)
            {
                double v = Math.Min(this.sl_scale.Value * obj, this.sl_scale.Maximum);
                v = Math.Max(v, this.sl_scale.Minimum);
                this.sl_scale.Value = v;
            }
        }

        private void sw_sound_Click(object sender, RoutedEventArgs e)
        {
            IsSoundable = !IsSoundable;
        }
    }

    [ValueConversion(typeof(Boolean), typeof(BitmapImage))]
    public class IsSoundableIcon : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
            {
                return new BitmapImage(new Uri("/Resources/Speaker.png", UriKind.Relative));
            }
            return new BitmapImage(new Uri("/Resources/Mute.png", UriKind.Relative));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    [ValueConversion(typeof(Double), typeof(Double))]
    public class GetHalf : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value / 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    /// <summary>
    /// values 0:scrollable, 1:viewportlength, 2:offset, 3:imglength, 4:imgscale
    /// </summary>
    public class LengthScaleToCenter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //double l = (double)values[0];
            //double s = (double)values[1];

            //return 0.5 * l * s;
            double scrollableLength = (double)values[0];
            double viewportLength = (double)values[1];
            double offset = (double)values[2];
            double imgLength = (double)values[3];
            double imgScale = (double)values[4];

            if (scrollableLength == 0)
            {
                return 0.5 * imgLength * imgScale;
            }
            return offset + 0.5 * viewportLength;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
