using Microsoft.Kinect.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kBrowser.Commands.Kinect
{
    class InitializeSoundCommand : AbstractInitializeKinectCommand
    {
        public InitializeSoundCommand(KinectSensorChooser sensorChooser)
            : base(sensorChooser)
        {
        }
    }
}
