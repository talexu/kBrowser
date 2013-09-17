using kBrowser.Commands;
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
        #region instance
        private static ViewCommands _instance = new ViewCommands();
        public static ViewCommands instance
        {
            get
            {
                return _instance;
            }
        }
        private ViewCommands()
        {
        }
        #endregion

        public static ICommand jumpToOverallViewCommand = new JumpToOverallViewCommand(ViewManager.instance);
        public static ICommand jumpToPictureViewCommand = new JumpToPictureViewCommand(ViewManager.instance);


    }
}
