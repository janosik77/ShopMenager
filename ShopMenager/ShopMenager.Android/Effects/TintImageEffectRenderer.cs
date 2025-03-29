using System;
using System.Linq;
using Android.Graphics;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ShopMenager.Droid.Effects;
using ShopMenager.Effects;

[assembly: ResolutionGroupName("ShopMenager")]
[assembly: ExportEffect(typeof(TintImageEffectRenderer), "TintImageEffect")]
namespace ShopMenager.Droid.Effects
{
    public class TintImageEffectRenderer : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                if (Control is ImageView imageView)
                {
                    var effect = (TintImageEffect)Element.Effects.FirstOrDefault(e => e is TintImageEffect);
                    if (effect != null)
                    {
                        imageView.SetColorFilter(effect.TintColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("TintImageEffect error: " + ex.Message);
            }
        }

        protected override void OnDetached()
        {
            if (Control is ImageView imageView)
            {
                imageView.ClearColorFilter();
            }
        }
    }
}
