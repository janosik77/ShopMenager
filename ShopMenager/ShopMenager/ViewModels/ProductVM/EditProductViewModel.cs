using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System;
using System.Threading.Tasks;

namespace ShopMenager.ViewModels.ProductVM
{
    public class EditProductViewModel : AUpdateItemViewModel<ProductDto>
    {
        public EditProductViewModel(IDataStore<ProductDto> itemService) : base(itemService, "Edit Product")
        {
        }

        #region Fields

        private int _productID;
        private int _categoryID;
        private string _productName;
        private decimal _price;
        private int _stock;
        private string _description;
        private string _photoPath;
        private string _categoryName;
        #endregion

        #region Props
        public string CategoryName
        {
            get => _categoryName;
            set => SetProperty(ref _categoryName, value);
        }
        public int ProductID
        {
            get => _productID;
            set => SetProperty(ref _productID, value);
        }

        public int CategoryID
        {
            get => _categoryID;
            set => SetProperty(ref _categoryID, value);
        }

        public string ProductName
        {
            get => _productName;
            set => SetProperty(ref _productName, value);
        }

        public decimal Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        public int Stock
        {
            get => _stock;
            set => SetProperty(ref _stock, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public string PhotoPath
        {
            get => _photoPath;
            set => SetProperty(ref _photoPath, value);
        }

        #endregion

        public override async Task LoadItem(int id)
        {
            try
            {
                var product = await ItemService.GetItemAsync(id);
                if (product != null)
                {
                    ProductID = product.ProductID;
                    CategoryID = product.CategoryID;
                    CategoryName = product.CategoryName;
                    ProductName = product.ProductName;
                    Price = product.Price;
                    Stock = product.Stock;
                    Description = product.Description;
                    PhotoPath = product.PhotoPath;
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędu
            }
        }

        public override ProductDto SetItem() => new ProductDto
        {
            CategoryID = CategoryID,
            ProductName = ProductName,
            ProductID = ProductID,
            CategoryName = CategoryName,
            Price = Price,
            Stock = Stock,
            Description = Description,
            PhotoPath = PhotoPath
        };

        public override bool ValidateSave()
        {
            if (string.IsNullOrWhiteSpace(ProductName)) return false;
            if (Price < 0) return false;
            return true;
        }
    }
}
