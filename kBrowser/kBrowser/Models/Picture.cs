using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace kBrowser.Models
{
    public class Picture : INotifyPropertyChanged
    {
        public Picture(string uri)
        {
            _uri = uri;
        }

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
                    OnPropertyChanged(this, "fileName");
                }
            }
        }

        /// <summary>
        /// file name
        /// </summary>
        public string fileName
        {
            get
            {
                return System.IO.Path.GetFileNameWithoutExtension(_uri);
            }
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
