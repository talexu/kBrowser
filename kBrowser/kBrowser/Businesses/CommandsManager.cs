using kBrowser.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kBrowser.Businesses
{
    class CommandsManager
    {
        #region instance
        private static CommandsManager _instance = new CommandsManager();
        public static CommandsManager instance
        {
            get
            {
                return _instance;
            }
        }
        private CommandsManager()
        {
        }
        #endregion

        public static ICommand jumpToOverallViewCommand = new JumpToOverallViewCommand(ViewManager.instance);
        public static ICommand jumpToPictureViewCommand = new JumpToPictureViewCommand(ViewManager.instance);


    }
}
