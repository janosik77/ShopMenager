using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System;

namespace ShopMenager.ViewModels.PaymentVM
{
    public class AddpaymentViewModel : AAddItemViewModel<PaymentDto>
    {
        public AddpaymentViewModel(IDataStore<PaymentDto> itemService, string title) : base(itemService, title)
        {
            PaymentDate = DateTime.Now;
        }

        #region Properties

        private int _orderID;
        public int OrderID
        {
            get => _orderID;
            set => SetProperty(ref _orderID, value);
        }

        private DateTime _paymentDate;
        public DateTime PaymentDate
        {
            get => _paymentDate;
            set => SetProperty(ref _paymentDate, value);
        }

        private decimal _amount;
        public decimal Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);
        }

        private PaymentMethods _paymentMethod;
        public PaymentMethods PaymentMethod
        {
            get => _paymentMethod;
            set => SetProperty(ref _paymentMethod, value);
        }

        private PaymentStatuses _paymentStatus;
        public PaymentStatuses PaymentStatus
        {
            get => _paymentStatus;
            set => SetProperty(ref _paymentStatus, value);
        }

        #endregion

        public override PaymentDto SetItem() => new PaymentDto
        {
            //OrderID = OrderID,
            //CustomerID = CustomerID,
            //Amount = Amount,
            //CustomerName = CustomerName,
            //PaymentDate = PaymentDate,
            //PaymentMethodName = PaymentMethodName,
            //PaymentMethodID = PaymentMethodID
        };

        public override bool ValidateSave()
        {
            // Przykład
            return OrderID > 0 && Amount > 0;
        }
    }
}
