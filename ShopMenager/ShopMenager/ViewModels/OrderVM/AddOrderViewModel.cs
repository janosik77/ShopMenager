using ShopMenager.BuissnesLogic;
using ShopMenager.Helpers;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.OrderVM
{
    public class AddOrderViewModel : AAddItemViewModel<OrderDto>
    {
        public AddOrderViewModel(IDataStore<OrderDto> itemService, 
            IDataStore<EmployeeDto>employeeDataStore, 
            IDataStore<CustomerDto>customerDataStore,
            IDataStore<ProductDto>productDataStore,
            IDataStore<Discounts> discountDataStore) : base(itemService, "Create Order")
        {
            OrderPositions = new ObservableCollection<ProductForOrderView>();
            AddProductCommand = new Command(AddToProductList, CanAdd);
            RemovePositionCommand = new Command<ProductForOrderView>(OnRemovePosition);
            _customerDataStore = customerDataStore;
            _employeeDataStore = employeeDataStore;
            _productDataStore = productDataStore;
            _discountsDataStore = discountDataStore;
            OrderDate = DateTime.Now;
        }

        #region Fields

        IDataStore<CustomerDto> _customerDataStore;
        IDataStore<EmployeeDto> _employeeDataStore;
        IDataStore<ProductDto> _productDataStore;
        IDataStore<Discounts> _discountsDataStore;

        #endregion

        #region Properties

        //Lista produktów w order dla widoku
        private ObservableCollection<ProductForOrderView> _orderPositions;
        public ObservableCollection<ProductForOrderView> OrderPositions
        {
            get => _orderPositions;
            set => SetProperty(ref _orderPositions, value);
        } 

        //Select Props
        private List<KeyValueItem> _customers;
        private List<KeyValueItem> _employees;
        private List<KeyValueItem> _products;
        private List<KeyValueItem> _discounts;
        public List<KeyValueItem> Customers
        {
            get => _customers;
            set => SetProperty(ref _customers, value);
        }   
        public List<KeyValueItem> Employees
        {
            get => _employees;
            set => SetProperty(ref _employees, value);
        }       
        public List<KeyValueItem> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }        
        public List<KeyValueItem> AllDiscounts
        {
            get => _discounts;
            set => SetProperty(ref _discounts, value);
        }


        private KeyValueItem _selectedCustomer;
        private KeyValueItem _selectedEmployee;
        private KeyValueItem _selectedProduct;
        private KeyValueItem _selectedDiscount;
        public KeyValueItem SelectedCustomer
        {
            get => _selectedCustomer;
            set => SetProperty(ref _selectedCustomer, value);
        }       
        public KeyValueItem SelectedEmployee
        {
            get =>_selectedEmployee;
            set => SetProperty(ref _selectedEmployee, value);
        }
        public KeyValueItem SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                SetProperty(ref _selectedProduct, value);
                AddProductCommand.ChangeCanExecute();
            }
        }
        public KeyValueItem SelectedDiscount
        {
            get => _selectedDiscount;
            set => SetProperty(ref _selectedDiscount, value);
        }


        ///view Props
        private DateTime _orderDate;
        private string _status;
        private int _quantity;
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
        public int ProdQuantity
        {
            get { return _quantity; }
            set 
                {
                    if (SetProperty(ref _quantity, value))
                    AddProductCommand.ChangeCanExecute();
                }
            }

        #endregion

        #region Commands
        public Command AddProductCommand { get; }
        public Command<ProductForOrderView> RemovePositionCommand { get; }
        #endregion

        #region Methods

        public override OrderDto SetItem() 
        {
            var order = new OrderDto
            {
                CustomerID = SelectedCustomer.Key,
                EmployeeID = SelectedEmployee.Key,
                OrderDate = OrderDate,
                Status = Status,
            };

            var orderDet = OrderPositions
                .Select(p => new OrderDetailDto
                {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    UnitPrice = p.Total/p.Quantity,
                    Quantity = p.Quantity,
                    DiscountID = AllDiscounts.FirstOrDefault(d => d.Value == p.DiscountName).Key,
                    Total = p.Total,
                })
                .ToList();
            order.OrderDetails = orderDet;
            return order;
        }
        public override bool ValidateSave()
        {
            if (SelectedCustomer == null || SelectedEmployee == null)
                return false;
            return SelectedCustomer.Key > 0 && SelectedEmployee.Key > 0;
        }
        private bool CanAdd ()
        {
            if (_selectedProduct != null && ProdQuantity != 0) { return true; }
            return false;         
        }
        private void AddToProductList ()
        {
            bool item = OrderPositions?.Any(p => p.ProductID == SelectedProduct.Key) ?? false;

            if (item && ProdQuantity != 0)
            {
                var prod = OrderPositions?.FirstOrDefault(p => p.ProductID == SelectedProduct.Key);
                prod.Quantity += ProdQuantity;
                prod.DiscountName = SelectedDiscount.Value;
                ProdQuantity = 0;
                SelectedProduct = null;
            } else if (ProdQuantity != 0 && SelectedDiscount != null)
            {
                var prod = DataStoreEntities.DataStoreProducts.FirstOrDefault(p => p.ProductID == SelectedProduct.Key);
                OrderPositions.Add(new ProductForOrderView
                {
                    ProductID = prod.ProductID,
                    Quantity = ProdQuantity,
                    ProductName = prod.ProductName,
                    DiscountName = SelectedDiscount.Value,
                    Total = ProdQuantity * prod.Price
                });
                ProdQuantity = 0;
                SelectedProduct = null;
                SelectedDiscount = null;   
            }
        }
        private void OnRemovePosition(ProductForOrderView item)
        {
            OrderPositions.Remove(item);
        }
        public override async Task OnAppearingAsync()
        {
            Customers = await DataStoreEntities.GetCustomerKeyValueItemsAsync(_customerDataStore);
            Employees = await DataStoreEntities.GetEmployeeKeyValueItemsAsync(_employeeDataStore);
            Products = await DataStoreEntities.GetProductKeyValueItemsAsync(_productDataStore);
            AllDiscounts = await DataStoreEntities.GetDiscountKeyValueItemsAsync(_discountsDataStore);
        }
        
        #endregion
    }
}