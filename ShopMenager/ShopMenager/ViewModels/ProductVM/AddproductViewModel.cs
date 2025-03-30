using ShopMenager.Helpers;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;


namespace ShopMenager.ViewModels.ProductVM
{
    public class AddproductViewModel : AAddItemViewModel<ProductDto>
    {
        public AddproductViewModel(IDataStore<ProductDto> itemService, IDataStore<CategoryDto> categoryDataStore) : base(itemService, "Create Product")
        {
            _categoryDataStore = categoryDataStore;
        }
        #region Properties
        private readonly IDataStore<CategoryDto> _categoryDataStore;
        private ObservableCollection<KeyValueItem> _categories;
        public ObservableCollection<KeyValueItem> Categories
        {
            get => _categories;
            set => SetProperty(ref _categories, value);
        }

        private KeyValueItem _selectedCategory;
        public KeyValueItem SelectedCategory
        {
            get => _selectedCategory;
            set => SetProperty(ref _selectedCategory, value);
        }

        private string _productName;
        public string ProductName
        {
            get => _productName;
            set => SetProperty(ref _productName, value);
        }

        private decimal _price;
        public decimal Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        private int _stock;
        public int Stock
        {
            get => _stock;
            set => SetProperty(ref _stock, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private string _photoPath;
        public string PhotoPath
        {
            get => _photoPath;
            set => SetProperty(ref _photoPath, value);
        }

        #endregion

        #region Methodss
        public override async Task OnAppearingAsync()
        {
            Categories = await GetCategoryItemsAsync();
        }

        public override ProductDto SetItem() => new ProductDto
        {
            CategoryID = SelectedCategory.Key,
            ProductName = ProductName,
            CategoryName = SelectedCategory.Value??" ",
            Price = Price,
            Stock = Stock,
            Description = Description,
            PhotoPath = PhotoPath
        };

        public override bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(ProductName) && Price > 0;
        }
        public async Task<ObservableCollection<KeyValueItem>> GetCategoryItemsAsync()
        {
            var categories = await _categoryDataStore.GetItemsAsync();
            var keyValueItems = categories.Select(c => new KeyValueItem
            {
                Key = c.CategoryID,
                Value = c.CategoryName
            }).ToList();
            return new ObservableCollection<KeyValueItem>(keyValueItems);
        }
        #endregion

    }
}
