using kBrowser.Commands.Kinect;
using kBrowser.Commands.Model;
using kBrowser.Utilities;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kBrowser.Businesses
{
    class Initializations
    {
        private static readonly KinectSensorChooser _sensorChooser = null;

        public static ICommand loadPicturesCommand = new LoadDemoDataCommand(ViewModels.instance.folders);
        public static ICommand initKinectCameraCommand = new InitializeCameraCommand(_sensorChooser);
        public static ICommand stopKinect = new StopKinectCommand(_sensorChooser);

        public static void Initialize(IDictionary<string, object> initializationParameters = null)
        {
            loadPicturesCommand.Execute(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, Config.pictureFolder));
            //initKinectCameraCommand.Execute(
            //    new Tuple<KinectRegion, KinectSensorChooserUI>(
            //        TypeHelper.ToType<KinectRegion>(initializationParameters["kinectRegion"]), TypeHelper.ToType<KinectSensorChooserUI>(initializationParameters["sensorChooserUi"])));
        }
    }
}
