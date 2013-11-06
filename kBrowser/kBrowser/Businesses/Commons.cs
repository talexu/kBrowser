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
        public static AbstractInitializer getNonKinectInitializer()
        {
            IInitializerFactory factory = new InitializerFactory();
            return factory.createNonKinectInitializer(new SoDictionary(Config.k_loadDataCommand, ModelCommands.loadPicturesCommand));
        }

        public static AbstractInitializer getInitializer(IDictionary<string, object> parameters = null)
        {
            parameters = parameters == null ? new SoDictionary() : parameters;

            parameters.Add(Config.k_loadDataCommand, ModelCommands.loadPicturesCommand);

            IInitializerFactory factory = new InitializerFactory();
            return factory.createInitializer(parameters);
        }
    }
}
