using ShopMenager.Models;
using ShopMenager.ViewModels.OrderitemsVM;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.OrderItemsV
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrdersItemView : BasePage<OrdersItemsViewModel>
	{
		public OrdersItemView()
		{
			InitializeComponent ();
		}
	}
}