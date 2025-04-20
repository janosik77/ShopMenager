using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.PaymentsV;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.PaymentVM
{
    public class PaymentDetailViewModel : ADetailsItemViewModel<PaymentDto>
    {
        public PaymentDetailViewModel(IDataStore<PaymentDto> itemService) : base(itemService, "Payment Detail")
        {
        }
        #region Fields
        private int _paymentID;
        private int _orderID;
        private DateTime _paymentDate;
        private decimal _amount;
        private int _paymentMethodID;
        private string _paymentStatusName;
        private int _paymentStatusID;
        private string _paymentMethodName;
        private string _customerName;
        private int _customerID;
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

        public int PaymentMethodID
        {
            get => _paymentMethodID;
            set => SetProperty(ref _paymentMethodID, value);
        }

        public string PaymentMethodName
        {
            get => _paymentMethodName;
            set => SetProperty(ref _paymentMethodName, value);
        }
        public string PaymentStatusName
        {
            get => _paymentStatusName;
            set => SetProperty(ref _paymentStatusName, value);
        }
        public int PaymentStatusID
        {
            get => _paymentStatusID;
            set => SetProperty(ref _paymentStatusID, value);
        }
        public string CustomerName
        {
            get => _customerName;
            set => SetProperty(ref _customerName, value);
        }
        public int CustomerID
        {
            get => _customerID;
            set => SetProperty(ref _customerID, value);
        }

        #endregion

        public override async Task LoadItem(int id)
        {
            try
            {
                var payment = await ItemService.GetItemAsync(id);
                if (payment != null)
                {
                    PaymentID = payment.PaymentID;
                    OrderID = payment.OrderID;
                    CustomerID = payment.CustomerID;
                    CustomerName = payment.CustomerName;
                    PaymentDate = payment.PaymentDate;
                    Amount = payment.Amount;
                    PaymentMethodID = payment.PaymentMethodID;
                    PaymentMethodName = payment.PaymentMethodName;
                    PaymentStatusID = payment.PaymentStatusID;
                    PaymentStatusName = payment.PaymentStatusName;
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędu
            }
        }

        protected override async Task GoToUpdatePage()
            => await Shell.Current
            .GoToAsync($"{nameof(EditPaymentView)}?{nameof(EditPaymentViewModel.ItemId)}={PaymentID}");
        protected override async Task GoToUpdatePage(PaymentDto item)
            => await Shell.Current
            .GoToAsync($"{nameof(EditPaymentView)}?{nameof(EditPaymentViewModel.ItemId)}={item.PaymentID}");
    }
}
