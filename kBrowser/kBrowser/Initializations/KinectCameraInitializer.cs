using kBrowser.Businesses;
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

namespace kBrowser.Initializations
{
    class KinectCameraInitializer : AbstractInitializer
    {
        private ICommand _initializeKinectCameraCommand;
        private KinectRegion _kinectRegion;
        private KinectSensorChooserUI _kinectSensorChooserUI;

        public KinectCameraInitializer(IDictionary<string, object> parameters)
            : base(parameters)
        {
            _initializeKinectCameraCommand = TypeHelper.GetObjectFromIDictionary<ICommand>(_parameters, Config.k_initlizeKinectCameraCommand);
            _kinectRegion = TypeHelper.GetObjectFromIDictionary<KinectRegion>(_parameters, Config.k_kinectRegion);
            _kinectSensorChooserUI = TypeHelper.GetObjectFromIDictionary<KinectSensorChooserUI>(_parameters, Config.k_kinectSensorChooserUI);
        }

        public override void run()
        {
            SoDictionary parameters = new SoDictionary(Config.k_kinectRegion, _kinectRegion, Config.k_kinectSensorChooserUI, _kinectSensorChooserUI);
            _initializeKinectCameraCommand.Execute(parameters);
            base.run();
        }
    }
}
