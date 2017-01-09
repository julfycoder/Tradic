using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tradic.ViewModel
{
    public abstract class ViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ViewModel()
        {
            Initialize();
        }

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void Initialize()
        {
            InitializeFields();
            InitializeEvents();
            InitializeCommands();
            InitializeProperties();
        }
        protected virtual void InitializeCommands() { }
        protected virtual void InitializeProperties() { }
        protected virtual void InitializeEvents() { }
        protected virtual void InitializeFields() { }
    }
}
