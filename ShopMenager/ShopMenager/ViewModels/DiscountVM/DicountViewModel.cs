using ShopMenager.Models;
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.ViewModels.CustomerVM;
using ShopMenager.Views.CustomerV;
using ShopMenager.Views.DiscountV;
using System;
using System.Threading.Tasks;

namespace ShopMenager.ViewModels.DiscountVM
{
    public class DicountViewModel : AListItemViewModel<Discount>
    {
        public DicountViewModel(IApiService<Discount> itemService, INavigationService navigationService, string title) : base(itemService, navigationService, title)
        {
        }

        public override Task GoToAddPage() => NavService.NavigateToAsync(nameof(AddDiscountView));

        public override async Task GoToDetailsPage(Discount item) 
            => await NavService.NavigateToAsync($"{nameof(DiscountDetailView)}?{nameof(DiscountsDetailsViewModel.ItemId)}={item.DiscountID}");
    }
}
