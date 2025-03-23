using ShopMenager.ViewModels.OrderVM;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.OrderV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersPage : BasePage<OrdersViewModel>
    {
        public OrdersPage()
        {
            InitializeComponent();
        }
    }
}