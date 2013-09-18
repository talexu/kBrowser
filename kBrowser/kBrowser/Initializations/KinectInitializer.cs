using kBrowser.Businesses;
using kBrowser.Utilities;
using Microsoft.Kinect.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kBrowser.Initializations
{
    abstract class KinectInitializer : AbstractInitializer
    {
        protected KinectSensorChooser _sensorChooser;

        public KinectInitializer(IDictionary<string, object> parameters)
            : base(parameters)
        {
            _sensorChooser = TypeHelper.GetFromIDictionary<string, object, KinectSensorChooser>(_parameters, Config.k_sensorChooser);
        }
    }
}
