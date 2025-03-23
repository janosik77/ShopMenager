using ShopMenager.ViewModels.PaymentVM;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.PaymentsV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentsPage : BasePage<PaymentsViewModel>
    {
        public PaymentsPage()
        {
            InitializeComponent();
        }
    }
}