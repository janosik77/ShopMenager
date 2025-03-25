using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.CategoryV;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.CategoryVM
{
    public class CategoriesViewModel : AListItemViewModel<Categories>
    {
        public CategoriesViewModel(IDataStore<Categories> itemService) : base(itemService, "Categories")
        {
        }

        public override Task GoToAddPage() => Shell.Current.GoToAsync(nameof(AddCategoryView));

        public override async Task GoToDetailsPage(Categories item) 
            => await Shell.Current.
            GoToAsync($"{nameof(CategoryDetailView)}?{nameof(CategoryDetailViewModel.ItemId)}={item.CategoryId}");
    }
}
