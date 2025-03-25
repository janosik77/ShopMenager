using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.PaymentsV;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.PaymentVM
{
    public class PaymentsViewModel : AListItemViewModel<Payments>
    {
        public PaymentsViewModel(IDataStore<Payments> itemService) : base(itemService, "Payments")
        {
        }

        public override Task GoToAddPage() => Shell.Current.GoToAsync(nameof(AddPaymentView));

        public override async Task GoToDetailsPage(Payments item)
        => await Shell.Current
            .GoToAsync($"{nameof(PaymentDetailView)}?{nameof(PaymentDetailViewModel.ItemId)}={item.PaymentID}");
    }
}
