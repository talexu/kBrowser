using kBrowser.Businesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kBrowser.Commands
{
    abstract class AbstractViewCommand : ICommand
    {
        protected ViewManager _vm;
        public AbstractViewCommand(ViewManager vm)
        {
            _vm = vm;
        }

        public virtual bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public virtual void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
