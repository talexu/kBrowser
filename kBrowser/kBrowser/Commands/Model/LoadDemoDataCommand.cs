using kBrowser.Models.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kBrowser.Commands.Model
{
    class LoadDemoDataCommand : AbstractLoadDataCommand
    {
        public LoadDemoDataCommand(ObservableCollection<PictureFolder> folders)
            : base(folders)
        {
        }
    }
}
