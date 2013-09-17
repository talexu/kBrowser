using kBrowser.Models.Entity;
using kBrowser.Models.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace kBrowser.Businesses
{
    class ViewModels : INotifyPropertyChanged
    {
        #region
        private static ViewModels _instance = new ViewModels();
        public static ViewModels instance
        {
            get
            {
                return _instance;
            }
        }
        private ViewModels()
        {
        }
        #endregion

        private IDictionary<ViewType, FrameworkElement> _views = new Dictionary<ViewType, FrameworkElement>();
        public IDictionary<ViewType, FrameworkElement> views
        {
            get
            {
                return _views;
            }
        }

        private ObservableCollection<PictureFolder> _folders = new ObservableCollection<PictureFolder>();
        public ObservableCollection<PictureFolder> folders
        {
            get
            {
                return _folders;
            }
        }

        public static ViewType overallViewType = ViewType.overall;
        public static ViewType pictureViewType = ViewType.picture;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(object sender, string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
