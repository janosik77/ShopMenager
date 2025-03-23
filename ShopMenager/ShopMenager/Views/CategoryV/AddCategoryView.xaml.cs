using ShopMenager.ViewModels.CategoryVM;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.CategoryV
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddCategoryView : BasePage<AddCategoryViewModel>
	{
		public AddCategoryView ()
		{
			InitializeComponent ();
		}
	}
}