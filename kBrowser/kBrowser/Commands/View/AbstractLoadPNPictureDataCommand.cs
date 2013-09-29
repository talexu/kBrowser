using kBrowser.Businesses;
using kBrowser.Models.Entity;
using kBrowser.Models.View;
using kBrowser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace kBrowser.Commands.View
{
    abstract class AbstractLoadPNPictureDataCommand : ICommand
    {
        protected IDictionary<ViewType, FrameworkElement> _views;
        protected ICommand _loadPictureDataCommand;

        public AbstractLoadPNPictureDataCommand(IDictionary<string, object> parameters)
        {
            _views = TypeHelper.GetObjectFromIDictionary<IDictionary<ViewType, FrameworkElement>>(parameters, Config.k_views);
            _loadPictureDataCommand = TypeHelper.GetObjectFromIDictionary<ICommand>(parameters, Config.k_loadPictureDataCommand);
        }

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public abstract void Execute(object parameter);
    }
}
