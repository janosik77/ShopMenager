using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.CategoryV;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.CategoryVM
{
    public class CategoriesViewModel : AListItemViewModel<CategoryDto>
    {
        public CategoriesViewModel(IDataStore<CategoryDto> itemService) : base(itemService, "Categories")
        {
        }

        public override Task GoToAddPage() => Shell.Current.GoToAsync(nameof(AddCategoryView));

        public override async Task GoToDetailsPage(CategoryDto item) 
            => await Shell.Current.
            GoToAsync($"{nameof(CategoryDetailView)}?{nameof(CategoryDetailViewModel.ItemId)}={item.CategoryID}");
    }
}
