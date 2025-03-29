
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.PorductV;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.ProductVM
{
    public class ProductViewModel : AListItemViewModel<ProductDto>
    {
        public ProductViewModel(IDataStore<ProductDto> itemService) : base(itemService, "Products")
        {
        }

        public override Task GoToAddPage() => Shell.Current.GoToAsync(nameof(AddProductView));

        public override async Task GoToDetailsPage(ProductDto item)
        => await Shell.Current.GoToAsync($"{nameof(productDetailView)}?{nameof(ProductDetailViewModel.ItemId)}={item.ProductID}");
    }
}
