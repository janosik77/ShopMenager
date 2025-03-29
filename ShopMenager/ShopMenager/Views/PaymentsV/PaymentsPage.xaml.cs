using ShopMenager.ViewModels.PaymentVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.PaymentsV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentsPage : ContentPage
    {
        PaymentsViewModel _viewModel;
        public PaymentsPage()
        {
            InitializeComponent();
            BindingContext= _viewModel = App.Services.GetService<PaymentsViewModel>();

        }
        protected override void OnAppearing()
        {
            //base.OnAppearing();
            _viewModel.OnAppearing();

        }
    }
}