using ShopMenager.ViewModels.ProductVM;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.PorductV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : BasePage<ProductViewModel>
    {
        public ProductPage()
        {
            InitializeComponent();
        }
    }
}