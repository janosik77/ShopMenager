using ShopMenager.ViewModels.CategoryVM;
using ShopMenager.ViewModels.ReviewsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.CategoryV
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditCategoryView : ContentPage
	{
		public EditCategoryView ()
		{
			InitializeComponent ();
            BindingContext = App.Services.GetService<EditCategoryViewModel>();
        }
	}
}