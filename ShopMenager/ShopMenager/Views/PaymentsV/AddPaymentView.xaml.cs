
using ShopMenager.ViewModels.OrderVM;
using ShopMenager.ViewModels.PaymentVM;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.PaymentsV
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPaymentView : ContentPage
	{
		public AddPaymentView ()
		{
			InitializeComponent ();
            BindingContext = App.Services.GetService<AddpaymentViewModel>();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is AddpaymentViewModel vm)
            {
                await vm.OnAppearingAsync();
            }
        }
    }
}