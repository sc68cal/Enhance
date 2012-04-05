using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using Enhance.Models;
using Enhance.Storage;
using Phoenix;
using Phoenix.Commands;

namespace Enhance.Features
{
    public class ManageDocumentsViewModel : ViewModelBase
    {
        public ManageDocumentsViewModel(EnhanceImage image)
        {
            var dirinfo = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            BackHomeCommand = new DelegateCommand(NavigateBack);
            Files = new ObservableCollection<FileInfo>(dirinfo.EnumerateFiles());
            Directories = new ObservableCollection<DirectoryInfo>(dirinfo.EnumerateDirectories());
        }

        public ICommand BackHomeCommand { get; private set; }

        public ObservableCollection<DirectoryInfo> Directories { get; set; }
        public ObservableCollection<FileInfo> Files { get; set; }
        public FileInfo SelectedFile { get; set; }

        public EnhanceImage Image { get; set; }
    }
}