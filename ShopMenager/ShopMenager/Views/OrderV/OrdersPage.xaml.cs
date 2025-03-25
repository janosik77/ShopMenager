
using ShopMenager.ViewModels.OrderVM;
using ShopMenager.ViewModels.ReviewsVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.OrderV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersPage : ContentPage
    {
        public OrdersPage()
        {
            InitializeComponent();
            BindingContext = App.Services.GetService<OrdersViewModel>();
        }
    }
}