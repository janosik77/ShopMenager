using ShopMenager.ViewModels.DiscountVM;
using ShopMenager.ViewModels.EmployeeVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.DiscountV
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DiscountDetailView : ContentPage
	{
		public DiscountDetailView ()
		{
			InitializeComponent ();
            BindingContext = App.Services.GetService<DiscountsDetailsViewModel>();
        }
	}
}