using kBrowser.Businesses;
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

        Tuple<Microsoft.Kinect.Toolkit.Controls.KinectRegion, Microsoft.Kinect.Toolkit.KinectSensorChooserUI> p;

        public KinectCameraInitializer(IDictionary<string, object> parameters)
            : base(parameters)
        {
            _initializeKinectCameraCommand = TypeHelper.GetFromIDictionary<ICommand>(_parameters, Config.k_initlizeKinectCameraCommand);
            _kinectRegion = TypeHelper.GetFromIDictionary<KinectRegion>(_parameters, Config.k_kinectRegion);
            _kinectSensorChooserUI = TypeHelper.GetFromIDictionary<KinectSensorChooserUI>(_parameters, Config.k_kinectSensorChooserUI);
        }

        public override void run()
        {
            _initializeKinectCameraCommand.Execute(new Tuple<KinectRegion, KinectSensorChooserUI>(_kinectRegion, _kinectSensorChooserUI));
            base.run();
        }
    }
}
