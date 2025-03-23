using ShopMenager.Models;
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.OrderItemsV;
using System;
using System.Threading.Tasks;

namespace ShopMenager.ViewModels.OrderitemsVM
{
    public class OrderPozDetailPageViewModel : ADetailsItemViewModel<OrderDetail>
    {
        public OrderPozDetailPageViewModel(IApiService<OrderDetail> itemService, INavigationService navigationService) : base(itemService, navigationService, "Pozition Detail")
        {
        }
        #region Fields
        private int _orderDetailsId;
        private int _orderID;
        private int _productID;
        private int _quantity;
        private decimal _unitPrice;
        private decimal _discount;
        #endregion

        #region Props
        public int OrderDetailsId
        {
            get => _orderDetailsId;
            set => SetProperty(ref _orderDetailsId, value);
        }

        public int OrderID
        {
            get => _orderID;
            set => SetProperty(ref _orderID, value);
        }

        public int ProductID
        {
            get => _productID;
            set => SetProperty(ref _productID, value);
        }

        public int Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        public decimal UnitPrice
        {
            get => _unitPrice;
            set => SetProperty(ref _unitPrice, value);
        }

        public decimal Discount
        {
            get => _discount;
            set => SetProperty(ref _discount, value);
        }
        #endregion

        public override async Task LoadItem(int id)
        {
            try
            {
                var detail = await ItemService.GetByIdAsync(id);
                if (detail != null)
                {
                    OrderDetailsId = detail.OrderDetailsId;
                    OrderID = detail.OrderID;
                    ProductID = detail.ProductID;
                    Quantity = detail.Quantity;
                    UnitPrice = detail.UnitPrice;
                    Discount = detail.Discount;
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędu
            }
        }

        protected override Task GoToUpdatePage()
            => NavService.NavigateToAsync($"{nameof(EditOrderItemView)}?{nameof(EditOrderDetailViewModel.OrderDetailsId)}={OrderDetailsId}");
    }
}
