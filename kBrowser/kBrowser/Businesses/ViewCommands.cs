using kBrowser.Commands.View;
using kBrowser.Models.Entity;
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
        public static ICommand loadPictureCommand = new LoadPictureDataCommand(ViewModels.instance.views);
        public static ICommand openPictureCommand = new OpenPictureCommand(new SoDictionary(Config.k_jumpToViewCommand, jumpToViewCommand, Config.k_loadPictureDataCommand, loadPictureCommand));
    }
}
