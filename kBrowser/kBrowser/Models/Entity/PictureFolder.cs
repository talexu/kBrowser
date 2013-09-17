using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kBrowser.Models.Entity
{
    class PictureFolder : INotifyPropertyChanged
    {
        private string _uri;
        /// <summary>
        /// uri
        /// </summary>
        public string uri
        {
            get
            {
                return _uri;
            }
            set
            {
                if (_uri != value)
                {
                    _uri = value;
                    OnPropertyChanged(this, "uri");
                }
            }
        }

        /// <summary>
        /// folder name
        /// </summary>
        public string folderName
        {
            get
            {
                return System.IO.Path.GetFileName(_uri);
            }
        }

        private ObservableCollection<Picture> _pictures = new ObservableCollection<Picture>();
        public ObservableCollection<Picture> pictures
        {
            get
            {
                return _pictures;
            }
        }

        public PictureFolder(string uri)
        {
            _uri = uri;
        }

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
