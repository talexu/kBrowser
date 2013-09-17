using kBrowser.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kBrowser.Businesses
{
    class DataManager : INotifyPropertyChanged
    {
        #region instance
        private static DataManager _instance = new DataManager();
        public static DataManager instance
        {
            get
            {
                return _instance;
            }
        }

        private DataManager()
        {
            
        }
        #endregion

        private ObservableCollection<PictureFolder> _folders = new ObservableCollection<PictureFolder>();
        public ObservableCollection<PictureFolder> folders
        {
            get
            {
                return _folders;
            }
        }

        #region load
        public void LoadData(string uri)
        {
            foreach (var folderURI in System.IO.Directory.EnumerateDirectories(uri))
            {
                PictureFolder folder = new PictureFolder(folderURI);
                foreach (var pictureURI in System.IO.Directory.EnumerateFiles(folderURI))
                {
                    folder.pictures.Add(new Picture(pictureURI));
                }
                _folders.Add(folder);
            }
        }

        public void LoadDemo()
        {
            LoadData(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, Config.pictureFolder));
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(object sender, string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
