using ShopMenager.ViewModels;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : BasePage<ProductPageViewModel>
    {
        public ProductPage()
        {
            InitializeComponent();
        }
    }
}