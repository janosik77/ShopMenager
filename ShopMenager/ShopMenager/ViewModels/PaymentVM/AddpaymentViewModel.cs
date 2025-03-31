using ShopMenager.BuissnesLogic;
using ShopMenager.Helpers;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopMenager.ViewModels.PaymentVM
{
    public class AddpaymentViewModel : AAddItemViewModel<PaymentDto>
    {
        private IDataStore<PaymentMethods> _paymentMethodDataStore;
        private IDataStore<OrderDto> _orderDataStore;
        public AddpaymentViewModel(IDataStore<PaymentDto> itemService,
            IDataStore<OrderDto> orderDataStore,
            IDataStore<PaymentMethods> paymentMethodService) : base(itemService, "Create Payment")
        {
            _paymentMethodDataStore = paymentMethodService;
            _orderDataStore = orderDataStore;
            PaymentDate = DateTime.Now;
        }

        #region Properties
        //Select Props
        private List<KeyValueItem> _order;
        private List<KeyValueItem> _paymentMethods;
        
        public List<KeyValueItem> Order
        {
            get => _order;
            set => SetProperty(ref _order, value);
        }
        public List<KeyValueItem> PaymentMethods
        {
            get => _paymentMethods;
            set => SetProperty(ref _paymentMethods, value);
        }



        private KeyValueItem _selectedPaymentMethod;
        public KeyValueItem SelectedPaymentMethod
        {
            get => _selectedPaymentMethod;
            set => SetProperty(ref _selectedPaymentMethod, value);
        }

        private KeyValueItem _selectedorder;
        public KeyValueItem SelectedOrder
        {
            get => _selectedorder;
            set => SetProperty(ref _selectedorder, value);
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


        #endregion

        public override PaymentDto SetItem() => new PaymentDto
        {
            OrderID = SelectedOrder.Key,
            Amount = Amount,
            PaymentDate = PaymentDate,
            PaymentMethodID = SelectedPaymentMethod.Key
        };

        public override bool ValidateSave()
        {
            if (SelectedOrder == null ) return false;
                return SelectedOrder.Key > 0 && Amount > 0;
        }
        public override async Task OnAppearingAsync()
        {
            Order = await DataStoreEntities.GetOrderKeyValueItemsAsync(_orderDataStore);
            PaymentMethods = await DataStoreEntities.GetpaymentMethodKeyValueItemsAsync(_paymentMethodDataStore);
        }
    }
}
