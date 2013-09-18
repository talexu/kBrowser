﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kBrowser.Businesses
{
    class Config
    {
        #region key
        // kinect
        public const string k_sensorChooser = "sensorChooser";
        public const string k_kinectRegion = "kinectRegion";
        public const string k_kinectSensorChooserUI = "kinectSensorChooserUI";

        // command
        public const string k_loadDataCommand = "loadDataCommand";
        public const string k_initlizeKinectCameraCommand = "initializeKinectCameraCommand";

        // property
        public const string k_decoratedInitializer = "decoratedInitializer";

        // view
        public const string k_viewType = "viewType";
        public const string k_frameworkElement = "frameworkElement";
        #endregion

        #region environment
        public const string pictureFolder = "Demo";
        #endregion
    }
}
