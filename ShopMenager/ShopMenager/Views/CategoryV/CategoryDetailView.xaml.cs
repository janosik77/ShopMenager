using ShopMenager.ViewModels.CategoryVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.CategoryV
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoryDetailView : ContentPage
	{
		public CategoryDetailView ()
		{
			InitializeComponent ();
			BindingContext = App.Services.GetService<CategoryDetailViewModel> ();
		}
	}
}