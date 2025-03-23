using ShopMenager.Models;
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System;
using System.Threading.Tasks;

namespace ShopMenager.ViewModels.PaymentVM
{
    public class EditPaymentViewModel : AUpdateItemViewModel<Payment>
    {
        public EditPaymentViewModel(IApiService<Payment> itemService, INavigationService navigationService) : base(itemService, navigationService, "Edit Payment")
        {
        }

        #region Fields

        private int _paymentID;
        private int _orderID;
        private DateTime _paymentDate;
        private decimal _amount;
        private int _paymentMethod;
        private int _paymentStatus;

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

        public int PaymentMethod
        {
            get => _paymentMethod;
            set => SetProperty(ref _paymentMethod, value);
        }

        public int PaymentStatus
        {
            get => _paymentStatus;
            set => SetProperty(ref _paymentStatus, value);
        }

        #endregion

        public override async Task LoadItem(int id)
        {
            try
            {
                var payment = await ItemService.GetByIdAsync(id);
                if (payment != null)
                {
                    PaymentID = payment.PaymentID;
                    OrderID = payment.OrderID;
                    PaymentDate = payment.PaymentDate;
                    Amount = payment.Amount;
                    PaymentMethod = payment.PaymentMethod;
                    PaymentStatus = payment.PaymentStatus;
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędu
            }
        }

        public override Payment SetItem() => new Payment
        {
            PaymentID = PaymentID,
            OrderID = OrderID,
            PaymentDate = PaymentDate,
            Amount = Amount,
            PaymentMethod = PaymentMethod,
            PaymentStatus = PaymentStatus
        };

        public override bool ValidateSave()
        {
            if (OrderID <= 0) return false;
            if (Amount <= 0) return false;
            return true;
        }
    }
}
