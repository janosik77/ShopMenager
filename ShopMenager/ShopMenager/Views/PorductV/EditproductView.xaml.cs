using ShopMenager.ViewModels.ProductVM;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.PorductV
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditProductView : ContentPage
	{
		public EditProductView()
		{
			InitializeComponent();
            BindingContext = App.Services.GetService<EditProductViewModel>();
        }
	}
}