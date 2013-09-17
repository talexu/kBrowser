using Microsoft.Kinect.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kBrowser.Commands.Kinect
{
    abstract class AbstractInitializeKinectCommand : ICommand
    {
        protected KinectSensorChooser _sensorChooser;

        public AbstractInitializeKinectCommand(KinectSensorChooser sensorChooser)
        {
            _sensorChooser = sensorChooser;
        }

        public virtual bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public virtual void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
