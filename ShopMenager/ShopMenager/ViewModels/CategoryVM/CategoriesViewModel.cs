using ShopMenager.Models;
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.ViewModels.CustomerVM;
using ShopMenager.Views.CategoryV;
using ShopMenager.Views.CustomerV;
using System;
using System.Threading.Tasks;

namespace ShopMenager.ViewModels.CategoryVM
{
    public class CategoriesViewModel : AListItemViewModel<Category>
    {
        public CategoriesViewModel(IApiService<Category> itemService, INavigationService navigationService) : base(itemService, navigationService, "Categories")
        {
        }

        public override Task GoToAddPage() => NavService.NavigateToAsync(nameof(AddCategoryView));

        public override async Task GoToDetailsPage(Category item) => await NavService.NavigateToAsync($"{nameof(CategoryDetailView)}?{nameof(CategoryDetailViewModel.ItemId)}={item.CategoryID}");
    }
}
