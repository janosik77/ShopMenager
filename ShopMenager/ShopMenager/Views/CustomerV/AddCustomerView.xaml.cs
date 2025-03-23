using ShopMenager.ViewModels.CustomerVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.CustomerV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCustomerView : BasePage<AddCustomerViewModel>
    {
        public AddCustomerView()
        {
            InitializeComponent();
        }
    }
}