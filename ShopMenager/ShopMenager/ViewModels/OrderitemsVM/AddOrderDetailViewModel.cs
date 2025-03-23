using ShopMenager.Models;
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views;
using System;


namespace ShopMenager.ViewModels.OrderitemsVM
{
    public class AddOrderDetailViewModel : AAddItemViewModel<OrderDetail>
    {
        public AddOrderDetailViewModel(IApiService<OrderDetail> itemService, INavigationService navigationService, string title) : base(itemService, navigationService, title)
        {
        }
        #region Properties

        private int _orderID;
        public int OrderID
        {
            get => _orderID;
            set => SetProperty(ref _orderID, value);
        }

        private int _productID;
        public int ProductID
        {
            get => _productID;
            set => SetProperty(ref _productID, value);
        }

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        private decimal _unitPrice;
        public decimal UnitPrice
        {
            get => _unitPrice;
            set => SetProperty(ref _unitPrice, value);
        }

        private decimal _discount;
        public decimal Discount
        {
            get => _discount;
            set => SetProperty(ref _discount, value);
        }

        #endregion

        public override OrderDetail SetItem() => new OrderDetail
        {
            OrderID = OrderID,
            ProductID = ProductID,
            Quantity = Quantity,
            UnitPrice = UnitPrice,
            Discount = Discount
        };

        public override bool ValidateSave()
        {
            return OrderID > 0 && ProductID > 0 && Quantity > 0;
        }
    }
}
