using FStvol.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FStvol.ViewModels
{
    public abstract class ViewModelBase : INPC_base
    {
        public INavigation NavigationService { get; set; }


        public abstract void Init(object data);

        
    }
}
