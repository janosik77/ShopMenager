
using ShopMenager.ViewModels.OrderitemsVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.OrderItemsV
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrdersItemView : ContentPage
    {
		public OrdersItemView()
		{
			InitializeComponent ();
            BindingContext = App.Services.GetService<OrdersItemsViewModel>();
        }
	}
}