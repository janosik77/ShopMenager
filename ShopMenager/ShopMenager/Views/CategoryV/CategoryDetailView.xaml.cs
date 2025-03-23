using ShopMenager.ViewModels.CategoryVM;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.CategoryV
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoryDetailView : BasePage<CategoryDetailViewModel>
	{
		public CategoryDetailView ()
		{
			InitializeComponent ();
		}
	}
}