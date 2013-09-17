using kBrowser.Businesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kBrowser.Commands
{
    class JumpToOverallViewCommand : AbstractViewCommand
    {
        public JumpToOverallViewCommand(ViewManager vm)
            : base(vm)
        {
        }

        public override void Execute(object parameter)
        {
            _vm.SwitchToView(BrowserView.overall);
        }
    }
}
