using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FStvol.Util
{
    public class INPC_base : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public void SetValue<T>(ref T target, T value, [CallerMemberName] string propertyName = null)
        {
            target = value;
            NotifyPropertyChanged(propertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
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
