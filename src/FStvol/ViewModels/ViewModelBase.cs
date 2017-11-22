﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FStvol.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public INavigation NavigationService { get; set; }



        public abstract void Init(object data);

        #region INotifyPropertyChanged
        public void SetValue<T>(ref T target, T value, [CallerMemberName] string propertyName = null)
        {
            target = value;
            NotifyPropertyChanged(propertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            NotifyPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public virtual void NotifyPropertyChanged(PropertyChangedEventArgs ea)
        {
            PropertyChanged?.Invoke(this, ea);
        }
        #endregion
    }
}
