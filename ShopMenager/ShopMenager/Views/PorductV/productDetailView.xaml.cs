using ShopMenager.ViewModels.ProductVM;
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