using ShopMenager.ViewModels.EmployeeVM;
using ShopMenager.ViewModels.OrderVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.OrderV
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderDetailView : ContentPage
	{
		public OrderDetailView ()
		{
			InitializeComponent ();
            BindingContext = App.Services.GetService<OrderDetailViewModel>();
        }
	}
}