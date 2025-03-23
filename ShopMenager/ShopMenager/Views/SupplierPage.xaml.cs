using ShopMenager.ViewModels;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupplierPage : BasePage<SupplierPageViewModel>
    {
        public SupplierPage()
        {
            InitializeComponent();
        }
    }
}