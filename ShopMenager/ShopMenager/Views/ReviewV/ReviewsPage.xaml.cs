using ShopMenager.ViewModels.ProductVM;
using ShopMenager.ViewModels.ReviewsVM;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.ReviewV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewsPage : ContentPage
    {
        public ReviewsPage()
        {
            InitializeComponent();

            try
            {
                BindingContext = App.Services.GetService<ReviewsViewModel>();
        }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.ToString()); if (ex.InnerException != null) System.Diagnostics.Debug.WriteLine("Blad ########################:" + ex.InnerException.ToString()); }

}

    }
}