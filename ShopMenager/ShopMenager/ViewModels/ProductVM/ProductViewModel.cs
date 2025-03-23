using ShopMenager.Models;
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.ViewModels.CustomerVM;
using ShopMenager.ViewModels.PaymentVM;
using ShopMenager.Views.CustomerV;
using ShopMenager.Views.PaymentsV;
using ShopMenager.Views.PorductV;
using System;
using System.Threading.Tasks;

namespace ShopMenager.ViewModels.ProductVM
{
    public class ProductViewModel : AListItemViewModel<Product>
    {
        public ProductViewModel(IApiService<Product> itemService, INavigationService navigationService, string title) : base(itemService, navigationService, title)
        {
        }

        public override Task GoToAddPage() => NavService.NavigateToAsync(nameof(AddProductView));

        public override async Task GoToDetailsPage(Product item)
        => await NavService.NavigateToAsync($"{nameof(productDetailView)}?{nameof(ProductDetailViewModel.ItemId)}={item.ProductID}");
    }
}
