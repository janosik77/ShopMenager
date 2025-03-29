using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System;
using System.Threading.Tasks;

namespace ShopMenager.ViewModels.OrderitemsVM
{
    public class EditOrderDetailViewModel : AUpdateItemViewModel<OrderDetailDto>
    {
        public EditOrderDetailViewModel(IDataStore<OrderDetailDto> itemService) : base(itemService, "Edit Order Detail")
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
                var detail = await ItemService.GetItemAsync(id);
                if (detail != null)
                {
                    //OrderDetailsId = detail.OrderDetailID;
                    //OrderID = detail.OrderID;
                    //ProductID = detail.ProductID;
                    //Quantity = detail.Quantity;
                    //UnitPrice = detail.UnitPrice;
                    //Discount = detail.Discount;
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędu
            }
        }

        public override OrderDetailDto SetItem() => new OrderDetailDto
        {
            //OrderDetailsId = OrderDetailsId,
            //OrderID = OrderID,
            //ProductID = ProductID,
            //Quantity = Quantity,
            //UnitPrice = UnitPrice,
            //Discount = Discount
        };

        public override bool ValidateSave()
        {
            if (OrderID <= 0) return false;
            if (ProductID <= 0) return false;
            if (Quantity < 1) return false;
            return true;
        }
    }
}
