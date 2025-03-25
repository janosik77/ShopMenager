using ShopMenager.ViewModels.CategoryVM;
using ShopMenager.ViewModels.CustomerVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.CustomerV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerDetailsView : ContentPage
    {
        public CustomerDetailsView()
        {
            InitializeComponent();
            BindingContext = App.Services.GetService<CustomerDetailViewModel>();
        }
    }
}