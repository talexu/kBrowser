using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace kBrowser.Businesses
{
    public class ViewManager
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

        private Dictionary<BrowserView, UIElement> _views = new Dictionary<BrowserView, UIElement>();

        /// <summary>
        /// Register a view
        /// </summary>
        /// <param name="browserView"></param>
        /// <param name="ui"></param>
        public void RegisterView(BrowserView browserView, UIElement ui)
        {
            if (!_views.ContainsKey(browserView))
            {
                _views.Add(browserView, ui);
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
    }

    public enum BrowserView
    {
        container,
        overall,
        picture
    }
}
