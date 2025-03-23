using ShopMenager.ViewModels;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersItems : BasePage<OrdersItemsViewModel>
    {
        public OrdersItems()
        {
            InitializeComponent();
        }
    }
}