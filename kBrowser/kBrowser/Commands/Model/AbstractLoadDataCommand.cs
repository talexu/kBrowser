﻿using kBrowser.Models.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kBrowser.Commands.Model
{
    abstract class AbstractLoadDataCommand : ICommand
    {
        private ObservableCollection<PictureFolder> _folders;

        public AbstractLoadDataCommand(ObservableCollection<PictureFolder> folders)
        {
            _folders = folders;
        }

        public virtual bool CanExecute(object parameter)
        {
            return _folders != null;
        }

        public event EventHandler CanExecuteChanged;

        public virtual void Execute(object parameter)
        {
            if (parameter != null)
            {
                string uri = parameter.ToString();

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
        }
    }
}
