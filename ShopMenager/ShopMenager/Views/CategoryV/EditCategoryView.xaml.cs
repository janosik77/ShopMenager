using ShopMenager.ViewModels.CategoryVM;
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
	public partial class EditCategoryView : BasePage<EditCategoryViewModel>
	{
		public EditCategoryView ()
		{
			InitializeComponent ();
		}
	}
}