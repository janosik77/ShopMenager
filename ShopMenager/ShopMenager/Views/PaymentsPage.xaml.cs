using ShopMenager.ViewModels;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentsPage : BasePage<PaymentsPageViewModel>
    {
        public PaymentsPage()
        {
            InitializeComponent();
        }
    }
}