using kBrowser.Commands.View;
using kBrowser.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kBrowser.Businesses
{
    class ViewCommands
    {
        public static ICommand registerViewCommand = new RegisterViewCommand(ViewModels.instance.views);
        public static ICommand jumpToViewCommand = new JumpToViewCommand(ViewModels.instance.views);
        public static ICommand openPictureCommand = new OpenPictureCommand(jumpToViewCommand, new LoadPictureDataCommand(ViewModels.instance.views));
    }
}
