using ShopMenager.ViewModels.EmployeeVM;
using ShopMenager.ViewModels.ReviewsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.ReviewV
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReviewdetailView : ContentPage
	{
		public ReviewdetailView ()
		{
			InitializeComponent ();
            BindingContext = App.Services.GetService<ReviewDetailViewModel>();
        }
	}
}