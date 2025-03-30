
using ShopMenager.ViewModels.ProductVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.PorductV
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddProductView : ContentPage
	{
		public AddProductView ()
		{
			InitializeComponent ();
            BindingContext = App.Services.GetService<AddproductViewModel>();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is AddproductViewModel vm)
            {
                await vm.OnAppearingAsync();
            }
        }
    }
}