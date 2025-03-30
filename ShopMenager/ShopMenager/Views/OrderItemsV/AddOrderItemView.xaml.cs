using ShopMenager.ViewModels.CategoryVM;
using ShopMenager.ViewModels.OrderitemsVM;
using ShopMenager.ViewModels.OrderVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.OrderItemsV
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddOrderItemView : ContentPage
	{
		public AddOrderItemView ()
		{
			InitializeComponent ();
            BindingContext = App.Services.GetService<AddOrderDetailViewModel>();
        }
	}
}