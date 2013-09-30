using kBrowser.Businesses;
using kBrowser.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace kBrowser.Commands.View
{
    abstract class AbstractViewCommand : ICommand
    {
        protected IDictionary<ViewType, FrameworkElement> _views;

        public AbstractViewCommand(IDictionary<ViewType, FrameworkElement> views)
        {
            _views = views;
        }

        public virtual bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public abstract void Execute(object parameter);
    }
}
