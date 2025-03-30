using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System.Threading.Tasks;

namespace ShopMenager.ViewModels.CategoryVM
{
    public class AddCategoryViewModel : AAddItemViewModel<CategoryDto>
    {
        public AddCategoryViewModel(IDataStore<CategoryDto> itemService) : base(itemService, "Create Category")
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

        #region Methode
        public override CategoryDto SetItem() => new CategoryDto
        {
            CategoryName = CategoryName,
            CategoryDescription = CategoryDescription
        };

        public override bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(CategoryName);
        }

        #endregion

    }
}
