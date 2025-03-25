using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using ShopMenager.ViewModels.OrderVM;
using ShopMenager.ViewModels.DiscountVM;

namespace ShopMenager.Views.DiscountV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiscountsPage : ContentPage
    {
        public DiscountsPage()
        {
            InitializeComponent();
            BindingContext = App.Services.GetService<DicountViewModel>();
        }
    }
}