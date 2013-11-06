using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kBrowser.Businesses
{
    class SoundManager
    {
        #region instance
        private static SoundManager _instance = new SoundManager();
        public static SoundManager Instance
        {
            get
            {
                return _instance;
            }
        }
        private SoundManager()
        {
        }
        #endregion

        public event Action<float> ScaleChanged;
    }
}
