using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;

namespace ShopMenager.ViewModels.CategoryVM
{
    public class AddCategoryViewModel : AAddItemViewModel<Categories>
    {
        public AddCategoryViewModel(IDataStore<Categories> itemService, string title) : base(itemService, title)
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

        public override Categories SetItem() => new Categories
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
