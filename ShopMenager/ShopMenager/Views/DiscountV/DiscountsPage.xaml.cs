using Xamarin.Forms.Xaml;
using ShopMenager.ViewModels.DiscountVM;

namespace ShopMenager.Views.DiscountV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiscountsPage : BasePage<DicountViewModel>
    {
        public DiscountsPage()
        {
            InitializeComponent();
        }
    }
}