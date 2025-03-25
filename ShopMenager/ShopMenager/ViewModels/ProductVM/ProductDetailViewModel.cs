
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.PorductV;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.ProductVM
{
    public class ProductDetailViewModel : ADetailsItemViewModel<Products>
    {
        public ProductDetailViewModel(IDataStore<Products> itemService) : base(itemService, "Product Detail")
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
        #endregion

        #region Props
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

        protected override Task GoToUpdatePage()
            => Shell.Current.GoToAsync($"{nameof(EditproductView)}?{nameof(EditProductViewModel.ProductID)}={ProductID}");
    }
}
