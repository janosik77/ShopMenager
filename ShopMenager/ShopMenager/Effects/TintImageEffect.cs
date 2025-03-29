using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ShopMenager.Effects
{
    public class TintImageEffect : RoutingEffect
    {
        public Color TintColor { get; set; } = Color.White;
        public TintImageEffect() : base("ShopMenager.TintImageEffect")
        {
        }
    }
}