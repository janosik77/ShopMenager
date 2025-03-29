using ShopMenager.ViewModels.EmployeeVM;
using ShopMenager.ViewModels.ProductVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.PorductV
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class productDetailView : ContentPage
	{
		public productDetailView ()
		{
			InitializeComponent ();
            BindingContext = App.Services.GetService<ProductDetailViewModel>();
        }
	}
}