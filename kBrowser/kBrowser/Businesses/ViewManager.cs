using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace kBrowser.Businesses
{
    class ViewManager
    {
        #region instance
        private static ViewManager _instance = new ViewManager();
        public static ViewManager instance
        {
            get
            {
                return _instance;
            }
        }
        private ViewManager()
        {
        }
        #endregion

        private Dictionary<BrowserView, FrameworkElement> _views = new Dictionary<BrowserView, FrameworkElement>();

        /// <summary>
        /// Register a view
        /// </summary>
        /// <param name="browserView"></param>
        /// <param name="fe"></param>
        public void RegisterView(BrowserView browserView, FrameworkElement fe)
        {
            if (!_views.ContainsKey(browserView))
            {
                _views.Add(browserView, fe);
            }
        }

        /// <summary>
        /// Switch to view
        /// </summary>
        /// <param name="browserView"></param>
        public void SwitchToView(BrowserView browserView)
        {
            foreach (var ui in _views)
            {
                ui.Value.Visibility = ui.Key == browserView ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Set the data of picture view
        /// </summary>
        /// <param name="dataContext"></param>
        public bool SetPictureData(object dataContext)
        {
            FrameworkElement pictureView;
            if (_views.TryGetValue(BrowserView.picture, out pictureView))
            {
                pictureView.DataContext = dataContext;
                return true;
            }
            return false;
        }
    }

    public enum BrowserView
    {
        container,
        overall,
        picture
    }
}
