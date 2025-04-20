using ShopMenager.ViewModels.OrderVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.OrderV
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditorderView : ContentPage
	{
		public EditorderView ()
		{
			InitializeComponent ();
            BindingContext = App.Services.GetService<EditOrderViewModel>();
        }
	}
}