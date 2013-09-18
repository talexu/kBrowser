using kBrowser.Businesses;
using kBrowser.Utilities;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace kBrowser.Commands.Kinect
{
    class InitializeCameraCommand : AbstractInitializeKinectCommand
    {
        public InitializeCameraCommand(KinectSensorChooser sensorChooser)
            : base(sensorChooser)
        {
        }

        public override void Execute(object parameter)
        {
            IDictionary<string, object> parameters = TypeHelper.ToType<IDictionary<string, object>>(parameter);
            if (parameters != null)
            {
                KinectRegion kinectRegion = TypeHelper.GetObjectFromIDictionary<KinectRegion>(parameters, Config.k_kinectRegion);
                KinectSensorChooserUI sensorChooserUi = TypeHelper.GetObjectFromIDictionary<KinectSensorChooserUI>(parameters, Config.k_kinectSensorChooserUI);

                // initialize the sensor chooser and UI
                _sensorChooser = new KinectSensorChooser();
                _sensorChooser.KinectChanged += SensorChooserOnKinectChanged;
                sensorChooserUi.KinectSensorChooser = _sensorChooser;
                _sensorChooser.Start();

                // Bind the sensor chooser's current sensor to the KinectRegion
                var regionSensorBinding = new Binding("Kinect") { Source = _sensorChooser };
                BindingOperations.SetBinding(kinectRegion, KinectRegion.KinectSensorProperty, regionSensorBinding);
            }
        }

        /// <summary>
        /// Called when the KinectSensorChooser gets a new sensor
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="args">event arguments</param>
        private void SensorChooserOnKinectChanged(object sender, KinectChangedEventArgs args)
        {
            if (args.OldSensor != null)
            {
                try
                {
                    args.OldSensor.DepthStream.Range = DepthRange.Default;
                    args.OldSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    args.OldSensor.DepthStream.Disable();
                    args.OldSensor.SkeletonStream.Disable();
                }
                catch (InvalidOperationException)
                {
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                }
            }

            if (args.NewSensor != null)
            {
                try
                {
                    args.NewSensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                    args.NewSensor.SkeletonStream.Enable();

                    try
                    {
                        args.NewSensor.DepthStream.Range = DepthRange.Near;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = true;
                    }
                    catch (InvalidOperationException)
                    {
                        // Non Kinect for Windows devices do not support Near mode, so reset back to default mode.
                        args.NewSensor.DepthStream.Range = DepthRange.Default;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    }
                }
                catch (InvalidOperationException)
                {
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                }
            }
        }
    }
}
