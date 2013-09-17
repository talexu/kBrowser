using Microsoft.Kinect.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kBrowser.Commands.Kinect
{
    class StopKinectCommand : AbstractInitializeKinectCommand
    {
        public StopKinectCommand(KinectSensorChooser sensorChooser)
            : base(sensorChooser)
        {
        }

        public override void Execute(object parameter)
        {
            if (_sensorChooser != null)
            {
                _sensorChooser.Stop();
            }
        }
    }
}
