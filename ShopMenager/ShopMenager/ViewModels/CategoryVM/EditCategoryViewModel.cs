using ShopMenager.Models;
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System;
using System.Threading.Tasks;

namespace ShopMenager.ViewModels.CategoryVM
{
    public class EditCategoryViewModel : AUpdateItemViewModel<Category>
    {
        public EditCategoryViewModel(IApiService<Category> itemService, INavigationService navigationService) : base(itemService, navigationService, "Edit Category")
        {
        }
        #region Fields

        private int _categoryID;
        private string _categoryName;
        private string _categoryDescription;

        #endregion

        #region Props

        public int CategoryID
        {
            get => _categoryID;
            set => SetProperty(ref _categoryID, value);
        }

        public string CategoryName
        {
            get => _categoryName;
            set => SetProperty(ref _categoryName, value);
        }

        public string CategoryDescription
        {
            get => _categoryDescription;
            set => SetProperty(ref _categoryDescription, value);
        }

        #endregion

        public override async Task LoadItem(int id)
        {
            try
            {
                var category = await ItemService.GetByIdAsync(id);
                if (category != null)
                {
                    CategoryID = category.CategoryID;
                    CategoryName = category.CategoryName;
                    CategoryDescription = category.CategoryDescription;
                }
                else
                {
                    // Obsługa braku obiektu
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędu
            }
        }

        public override Category SetItem() => new Category
        {
            CategoryID = CategoryID,
            CategoryName = CategoryName,
            CategoryDescription = CategoryDescription
        };

        public override bool ValidateSave()
        {
            if (string.IsNullOrWhiteSpace(CategoryName)) return false;
            return true;
        }
    }
}
