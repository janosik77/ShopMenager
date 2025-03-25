using ShopMenager.ViewModels.CategoryVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.CategoryV
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddCategoryView : ContentPage
    {
		public AddCategoryView ()
		{
			InitializeComponent ();
			BindingContext = App.Services.GetService<AddCategoryViewModel> ();
		}
	}
}