using kBrowser.Businesses;
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
    class RegisterViewCommand : AbstractViewCommand
    {
        public RegisterViewCommand(IDictionary<ViewType, FrameworkElement> views)
            : base(views)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            _views.Add(TypeHelper.GetEnumFromIDictionary<ViewType>(parameter, Config.k_viewType), TypeHelper.GetObjectFromIDictionary<FrameworkElement>(parameter, Config.k_frameworkElement));
        }
    }
}
