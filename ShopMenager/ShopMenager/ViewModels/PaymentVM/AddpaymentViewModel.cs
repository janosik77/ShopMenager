using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System;

namespace ShopMenager.ViewModels.PaymentVM
{
    public class AddpaymentViewModel : AAddItemViewModel<Payments>
    {
        public AddpaymentViewModel(IDataStore<Payments> itemService, string title) : base(itemService, title)
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

        public override Payments SetItem() => new Payments
        {
            OrderID = OrderID,
            PaymentDate = PaymentDate,
            Amount = Amount,
            PaymentMethod = PaymentMethod,
            PaymentStatus = PaymentStatus
        };

        public override bool ValidateSave()
        {
            // Przykład
            return OrderID > 0 && Amount > 0;
        }
    }
}
