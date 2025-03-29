using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.OrderV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.OrderVM
{
    public class OrderDetailViewModel : ADetailsItemViewModel<OrderDto>
    {
        public OrderDetailViewModel(IDataStore<OrderDto> itemService) : base(itemService, "Order Detail")
        {
        }
        #region Fields
        private int _orderID;
        private int _customerID;
        private int _employeeID;
        private DateTime _orderDate;
        private string _status;
        private string _customerName;
        private string _employeeName;
        private List<OrderDetailDto> _orderPositions;
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
        public string CustomerName 
        { 
            get => _customerName; 
            set => SetProperty(ref _customerName, value); 
        }
        public string EmployeeName 
        {
            get => _employeeName; 
            set => SetProperty(ref _employeeName, value); 
        }
        public List<OrderDetailDto> OrderPositions 
        { 
            get => _orderPositions; 
            set => SetProperty(ref _orderPositions, value) ; 
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
                    CustomerName = order.CustomerName;
                    EmployeeName = order.EmployeeName;
                    OrderPositions = order.OrderDetails.ToList();
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędu
            }
        }

        protected override Task GoToUpdatePage()
            => Shell.Current.GoToAsync($"{nameof(EditorderView)}?{nameof(EditOrderViewModel.OrderID)}={OrderID}");
        protected override Task GoToUpdatePage(OrderDto item)
        {
            return null;
        }
    }
}
