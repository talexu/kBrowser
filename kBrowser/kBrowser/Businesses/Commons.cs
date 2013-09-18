using kBrowser.Commands.Kinect;
using kBrowser.Commands.Model;
using kBrowser.Factories;
using kBrowser.Initializations;
using kBrowser.Models.Entity;
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
    class Commons
    {
        private static readonly KinectSensorChooser _sensorChooser = null;

        public static ICommand loadPicturesCommand = new LoadDemoDataCommand(ViewModels.instance.folders);
        public static ICommand initKinectCameraCommand = new InitializeCameraCommand(_sensorChooser);
        public static ICommand stopKinect = new StopKinectCommand(_sensorChooser);

        public static AbstractInitializer getNonKinectInitializer()
        {
            IDictionary<string, object> parameters = new SoDictionary();

            parameters.Add(Config.k_loadDataCommand, loadPicturesCommand);

            IInitializerFactory factory = new InitializerFactory();
            return factory.createNonKinectInitializer(parameters);
        }

        public static AbstractInitializer getInitializer(IDictionary<string, object> parameters = null)
        {
            parameters = parameters == null ? new SoDictionary() : parameters;

            parameters.Add(Config.k_loadDataCommand, loadPicturesCommand);
            parameters.Add(Config.k_initlizeKinectCameraCommand, initKinectCameraCommand);

            IInitializerFactory factory = new InitializerFactory();
            return factory.createInitializer(parameters);
        }
    }
}
