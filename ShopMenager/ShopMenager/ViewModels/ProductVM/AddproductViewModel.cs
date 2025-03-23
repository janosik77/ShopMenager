using ShopMenager.Models;
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.ViewModels.ProductVM
{
    public class AddproductViewModel : AAddItemViewModel<Product>
    {
        public AddproductViewModel(IApiService<Product> itemService, INavigationService navigationService, string title) : base(itemService, navigationService, title)
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

        public override Product SetItem() => new Product
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
