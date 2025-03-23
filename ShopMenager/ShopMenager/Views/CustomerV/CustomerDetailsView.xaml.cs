using ShopMenager.ViewModels.CategoryVM;
using ShopMenager.ViewModels.CustomerVM;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.CustomerV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerDetailsView : BasePage<CustomerDetailViewModel>
    {
        public CustomerDetailsView()
        {
            InitializeComponent();
        }
    }
}