using kBrowser.Commands.Kinect;
using Microsoft.Kinect.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kBrowser.Businesses
{
    class KinectCommands
    {
        private static readonly KinectSensorChooser _sensorChooser = null;

        public static ICommand initKinectCameraCommand = new InitializeCameraCommand(_sensorChooser);
        public static ICommand stopKinect = new StopKinectCommand(_sensorChooser);
    }
}
