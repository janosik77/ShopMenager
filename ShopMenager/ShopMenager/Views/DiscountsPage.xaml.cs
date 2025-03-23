using Xamarin.Forms.Xaml;
using ShopMenager.ViewModels;

namespace ShopMenager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiscountsPage : BasePage<DiscountsPageViewModel>
    {
        public DiscountsPage()
        {
            InitializeComponent();
        }
    }
}