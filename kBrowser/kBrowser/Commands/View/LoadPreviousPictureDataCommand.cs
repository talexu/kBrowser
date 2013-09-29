using kBrowser.Models.Entity;
using kBrowser.Models.View;
using kBrowser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace kBrowser.Commands.View
{
    class LoadPreviousPictureDataCommand : AbstractLoadPNPictureDataCommand
    {
        public LoadPreviousPictureDataCommand(IDictionary<string, object> parameters)
            : base(parameters)
        {
        }

        public override void Execute(object parameter)
        {
            LoadPictureData(false);
        }
    }
}
