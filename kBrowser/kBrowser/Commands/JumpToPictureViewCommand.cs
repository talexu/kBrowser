using kBrowser.Businesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kBrowser.Commands
{
    class JumpToPictureViewCommand : AbstractViewCommand
    {
        public JumpToPictureViewCommand(ViewManager vm)
            : base(vm)
        {

        }
        public override void Execute(object parameter)
        {
            if (_vm.SetPictureData(parameter))
            {
                _vm.SwitchToView(BrowserView.picture);
            }
        }
    }
}
