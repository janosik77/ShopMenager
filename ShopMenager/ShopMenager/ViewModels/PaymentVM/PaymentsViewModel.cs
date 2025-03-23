using ShopMenager.Models;
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.ViewModels.CustomerVM;
using ShopMenager.Views.CustomerV;
using ShopMenager.Views.PaymentsV;
using System;
using System.Threading.Tasks;

namespace ShopMenager.ViewModels.PaymentVM
{
    public class PaymentsViewModel : AListItemViewModel<Payment>
    {
        public PaymentsViewModel(IApiService<Payment> itemService, INavigationService navigationService) : base(itemService, navigationService, "Payments")
        {
        }

        public override Task GoToAddPage() => NavService.NavigateToAsync(nameof(AddPaymentView));

        public override async Task GoToDetailsPage(Payment item)
        => await NavService.NavigateToAsync($"{nameof(PaymentDetailView)}?{nameof(PaymentDetailViewModel.ItemId)}={item.PaymentID}");
    }
}
