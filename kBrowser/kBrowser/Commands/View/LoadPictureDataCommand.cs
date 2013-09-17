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
    class LoadPictureDataCommand : AbstractViewCommand
    {
        public LoadPictureDataCommand(IDictionary<ViewType, FrameworkElement> views)
            : base(views)
        {

        }

        public override bool CanExecute(object parameter)
        {
            if (_views != null)
            {
                return _views.ContainsKey(ViewType.picture);
            }
            return false;
        }

        public override void Execute(object parameter)
        {
            _views[ViewType.picture].DataContext = parameter;
        }
    }
}
