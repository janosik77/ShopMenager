using ShopMenager.Models;
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System;

namespace ShopMenager.ViewModels.OrderVM
{
    public class AddOrderViewModel : AAddItemViewModel<Order>
    {
        public AddOrderViewModel(IApiService<Order> itemService, INavigationService navigationService, string title) : base(itemService, navigationService, title)
        {
            OrderDate = DateTime.Now;
        }

        #region Properties

        private int _customerID;
        public int CustomerID
        {
            get => _customerID;
            set => SetProperty(ref _customerID, value);
        }

        private int _employeeID;
        public int EmployeeID
        {
            get => _employeeID;
            set => SetProperty(ref _employeeID, value);
        }

        private DateTime _orderDate;
        public DateTime OrderDate
        {
            get => _orderDate;
            set => SetProperty(ref _orderDate, value);
        }

        private string _status;
        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        #endregion

        public override Order SetItem() => new Order
        {
            CustomerID = CustomerID,
            EmployeeID = EmployeeID,
            OrderDate = OrderDate,
            Status = Status
        };

        public override bool ValidateSave()
        {
            // Przykład
            return CustomerID > 0 && EmployeeID > 0;
        }
    }
}
