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
            if (_views != null)
            {
                Tuple<ViewType, FrameworkElement> vf = TypeHelper.ToType<Tuple<ViewType, FrameworkElement>>(parameter);
                if (vf != null)
                {
                    return !_views.ContainsKey(TypeHelper.ToEnum<ViewType>(vf.Item1));
                }
            }
            return false;
        }

        public override void Execute(object parameter)
        {
            Tuple<ViewType, FrameworkElement> vf = TypeHelper.ToType<Tuple<ViewType, FrameworkElement>>(parameter);
            if (vf != null)
            {
                _views.Add(vf.Item1, vf.Item2);
            }
        }
    }
}
