
using ShopMenager.ViewModels.OrderVM;
using ShopMenager.ViewModels.ProductVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.OrderV
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddOrderView : ContentPage
	{
		public AddOrderView ()
		{
			InitializeComponent ();
            BindingContext = App.Services.GetService<AddOrderViewModel>();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is AddOrderViewModel vm)
            {
                await vm.OnAppearingAsync();
            }
        }
    }
}