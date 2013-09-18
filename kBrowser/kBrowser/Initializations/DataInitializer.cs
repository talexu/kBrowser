using kBrowser.Businesses;
using kBrowser.Models.Entity;
using kBrowser.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kBrowser.Initializations
{
    class DataInitializer : AbstractInitializer
    {
        private ICommand _loadDataCommand;

        public DataInitializer(IDictionary<string, object> parameter)
            : base(parameter)
        {
            _loadDataCommand = TypeHelper.GetFromIDictionary<ICommand>(_parameters, Config.k_loadDataCommand);
        }

        public override void run()
        {
            _loadDataCommand.Execute(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, Config.pictureFolder));
            base.run();
        }
    }
}
