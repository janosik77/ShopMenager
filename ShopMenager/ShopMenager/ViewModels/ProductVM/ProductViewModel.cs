
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.PorductV;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.ProductVM
{
    public class ProductViewModel : AListItemViewModel<Products>
    {
        public ProductViewModel(IDataStore<Products> itemService) : base(itemService, "Products")
        {
        }

        public override Task GoToAddPage() => Shell.Current.GoToAsync(nameof(AddProductView));

        public override async Task GoToDetailsPage(Products item)
        => await Shell.Current.GoToAsync($"{nameof(productDetailView)}?{nameof(ProductDetailViewModel.ItemId)}={item.ProductID}");
    }
}
