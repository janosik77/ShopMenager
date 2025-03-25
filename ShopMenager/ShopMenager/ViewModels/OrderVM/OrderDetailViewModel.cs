using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.OrderV;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.OrderVM
{
    public class OrderDetailViewModel : ADetailsItemViewModel<Orders>
    {
        public OrderDetailViewModel(IDataStore<Orders> itemService) : base(itemService, "Order Detail")
        {
        }
        #region Fields
        private int _orderID;
        private int _customerID;
        private int _employeeID;
        private DateTime _orderDate;
        private string _status;
        #endregion

        #region Props
        public int OrderID
        {
            get => _orderID;
            set => SetProperty(ref _orderID, value);
        }

        public int CustomerID
        {
            get => _customerID;
            set => SetProperty(ref _customerID, value);
        }

        public int EmployeeID
        {
            get => _employeeID;
            set => SetProperty(ref _employeeID, value);
        }

        public DateTime OrderDate
        {
            get => _orderDate;
            set => SetProperty(ref _orderDate, value);
        }

        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }
        #endregion

        public override async Task LoadItem(int id)
        {
            try
            {
                var order = await ItemService.GetItemAsync(id);
                if (order != null)
                {
                    OrderID = order.OrderID;
                    CustomerID = order.CustomerID;
                    EmployeeID = order.EmployeeID;
                    OrderDate = order.OrderDate;
                    Status = order.Status;
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędu
            }
        }

        protected override Task GoToUpdatePage()
            => Shell.Current.GoToAsync($"{nameof(EditorderView)}?{nameof(EditOrderViewModel.OrderID)}={OrderID}");
    }
}
