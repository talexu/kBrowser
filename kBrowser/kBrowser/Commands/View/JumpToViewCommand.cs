using kBrowser.Models.View;
using kBrowser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace kBrowser.Commands.View
{
    class JumpToViewCommand : AbstractViewCommand
    {
        public JumpToViewCommand(IDictionary<ViewType, FrameworkElement> views)
            : base(views)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            foreach (var fe in _views)
            {
                fe.Value.Visibility = fe.Key == TypeHelper.ToEnum<ViewType>(parameter) ? Visibility.Visible : Visibility.Collapsed;
            }
        }
    }
}
