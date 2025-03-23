using ShopMenager.Models;
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System;

namespace ShopMenager.ViewModels.CategoryVM
{
    public class AddCategoryViewModel : AAddItemViewModel<Category>
    {
        public AddCategoryViewModel(IApiService<Category> itemService, INavigationService navigationService, string title) : base(itemService, navigationService, title)
        {
        }


        #region Properties
        private string _categoryName;
        public string CategoryName
        {
            get => _categoryName;
            set => SetProperty(ref _categoryName, value);
        }
        private string _categoryDescription;
        public string CategoryDescription
        {
            get => _categoryDescription;
            set => SetProperty(ref _categoryDescription, value);
        }
        #endregion

        public override Category SetItem() => new Category
        {
            CategoryName = CategoryName,
            CategoryDescription = CategoryDescription
        };

        public override bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(CategoryName);
        }
    }
}
