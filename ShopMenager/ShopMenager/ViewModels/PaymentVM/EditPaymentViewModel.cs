using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System;
using System.Threading.Tasks;

namespace ShopMenager.ViewModels.PaymentVM
{
    public class EditPaymentViewModel : AUpdateItemViewModel<PaymentDto>
    {
        public EditPaymentViewModel(IDataStore<PaymentDto> itemService) : base(itemService, "Edit Payment")
        {
        }

        #region Fields

        private int _paymentID;
        private int _orderID;
        private DateTime _paymentDate;
        private decimal _amount;
        private PaymentMethods _paymentMethod;
        private PaymentStatuses _paymentStatus;

        #endregion

        #region Props

        public int PaymentID
        {
            get => _paymentID;
            set => SetProperty(ref _paymentID, value);
        }

        public int OrderID
        {
            get => _orderID;
            set => SetProperty(ref _orderID, value);
        }

        public DateTime PaymentDate
        {
            get => _paymentDate;
            set => SetProperty(ref _paymentDate, value);
        }

        public decimal Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);
        }

        public PaymentMethods PaymentMethod
        {
            get => _paymentMethod;
            set => SetProperty(ref _paymentMethod, value);
        }

        public PaymentStatuses PaymentStatus
        {
            get => _paymentStatus;
            set => SetProperty(ref _paymentStatus, value);
        }

        #endregion

        public override async Task LoadItem(int id)
        {
            try
            {
                var payment = await ItemService.GetItemAsync(id);
                if (payment != null)
                {
                    //PaymentID = payment.PaymentID;
                    //OrderID = payment.OrderID;
                    //CustomerID = payment.CustomerID;
                    //CustomerName = payment.CustomerName;
                    //PaymentDate = payment.PaymentDate;
                    //Amount = payment.Amount;
                    //PaymentMethod = payment.PaymentMethod;
                    //PaymentStatus = payment.PaymentStatus;
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędu
            }
        }

        public override PaymentDto SetItem() => new PaymentDto
        {
            OrderID = OrderID,
            PaymentDate = PaymentDate,
            //Amount = Amount,
            //CustomerID = CustomerID,
            //CustomerName = CustomerName,
            //PaymentDate = PaymentDate,
            //PaymentMethod = PaymentMethod,
            //PaymentStatus = PaymentStatus
        };

        public override bool ValidateSave()
        {
            if (OrderID <= 0) return false;
            if (Amount <= 0) return false;
            return true;
        }
    }
}
