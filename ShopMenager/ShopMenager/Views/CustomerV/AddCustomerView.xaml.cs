using ShopMenager.ViewModels.CustomerVM;
using ShopMenager.ViewModels.ReviewsVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.CustomerV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCustomerView : ContentPage
    {
        public AddCustomerView()
        {
            InitializeComponent();
            BindingContext = App.Services.GetService<AddCustomerViewModel>();
        }
    }
}