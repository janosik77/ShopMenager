using ShopMenager.ViewModels;
using ShopMenager.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ShopMenager
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
