using kBrowser.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kBrowser.Commands.View
{
    class OpenPictureCommand : ICommand
    {
        private ICommand _jumpToViewCommand, _loadPictureDataCommand;

        public OpenPictureCommand(ICommand jumpToViewCommand, ICommand loadPictureDataCommand)
        {
            _jumpToViewCommand = jumpToViewCommand;
            _loadPictureDataCommand = loadPictureDataCommand;
        }

        public bool CanExecute(object parameter)
        {
            return _jumpToViewCommand != null && _loadPictureDataCommand != null;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _jumpToViewCommand.Execute(ViewType.picture);
            _loadPictureDataCommand.Execute(parameter);
        }
    }
}
