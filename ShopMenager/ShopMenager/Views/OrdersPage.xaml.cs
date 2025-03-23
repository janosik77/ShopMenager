using ShopMenager.ViewModels;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersPage : BasePage<OrdersPageViewModel>
    {
        public OrdersPage()
        {
            InitializeComponent();
        }
    }
}