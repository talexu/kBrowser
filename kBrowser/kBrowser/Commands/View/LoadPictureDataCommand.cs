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
    class LoadPictureDataCommand : AbstractViewCommand
    {
        public LoadPictureDataCommand(IDictionary<ViewType, FrameworkElement> views)
            : base(views)
        {

        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            TypeHelper.GetFromIDictionary<ViewType, FrameworkElement>(_views, ViewType.picture).DataContext = parameter;
        }
    }
}
