
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;


namespace ShopMenager.ViewModels.ProductVM
{
    public class AddproductViewModel : AAddItemViewModel<Products>
    {
        public AddproductViewModel(IDataStore<Products> itemService, string title) : base(itemService, title)
        {
        }
        #region Properties

        private int _categoryID;
        public int CategoryID
        {
            get => _categoryID;
            set => SetProperty(ref _categoryID, value);
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

        public override Products SetItem() => new Products
        {
            CategoryID = CategoryID,
            ProductName = ProductName,
            Price = Price,
            Stock = Stock,
            Description = Description,
            PhotoPath = PhotoPath
        };

        public override bool ValidateSave()
        {
            // Przykład
            return !string.IsNullOrWhiteSpace(ProductName) && Price > 0;
        }
    }
}
