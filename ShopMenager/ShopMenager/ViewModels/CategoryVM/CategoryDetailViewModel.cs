using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.CategoryV;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.CategoryVM
{
    public class CategoryDetailViewModel : ADetailsItemViewModel<CategoryDto>
    {
        public CategoryDetailViewModel(IDataStore<CategoryDto> itemService) : base(itemService, "Category Detail")
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
                var category = await ItemService.GetItemAsync(id);
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

        protected override Task GoToUpdatePage()
            => Shell.Current.GoToAsync($"{nameof(EditCategoryView)}?{nameof(EditCategoryViewModel.CategoryID)}={CategoryID}");
        protected override Task GoToUpdatePage(CategoryDto item)
        {
            return null;
        }
    }
}
