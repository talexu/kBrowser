using kBrowser.Commands.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kBrowser.Businesses
{
    class ModelCommands
    {
        public static ICommand loadPicturesCommand = new LoadDemoDataCommand(ViewModels.instance.folders);
    }
}
