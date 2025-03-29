
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System;
using System.Threading.Tasks;

namespace ShopMenager.ViewModels.OrderVM
{
    public class EditOrderViewModel : AUpdateItemViewModel<OrderDto>
    {
        public EditOrderViewModel(IDataStore<OrderDto> itemService) : base(itemService, "Edit Order")
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
                    //CustomerName = order.CustomerName;
                    //EmployeeName = order.EmployeeName;
                    //OrderList = order.OrderDetails;
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędu
            }
        }

        public override OrderDto SetItem() => new OrderDto
        {
            OrderID = OrderID,
            CustomerID = CustomerID,
            EmployeeID = EmployeeID,
            OrderDate = OrderDate,
            Status = Status
        };

        public override bool ValidateSave()
        {
            if (CustomerID <= 0) return false;
            if (EmployeeID <= 0) return false;
            if (string.IsNullOrWhiteSpace(Status)) return false;
            return true;
        }
    }
}
