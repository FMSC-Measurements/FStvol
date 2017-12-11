using FStvol.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(FStvol.Droid.Renderers.CustomPickerRenderer))]

namespace FStvol.Droid.Renderers
{
    
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.InputType = Android.Text.InputTypes.TextFlagNoSuggestions;
            }
        }
    }
}
