using ShopMenager.Models;
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using ShopMenager.Views.Popups;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
using ShopMenager.ViewModels.Popups;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Pages;
using System.Linq;


namespace ShopMenager.ViewModels
{
    public class CustomersPageViewModel : BaseViewModel
    {

        #region Constructor
        public CustomersPageViewModel
            (INavigationService navigationService,
            IApiService<Customer> customerService) : base(navigationService)
        {
            Title = "Customers";

            _customerService = customerService;
            Customers = new ObservableCollection<Customer>();

            Device.BeginInvokeOnMainThread(async () => await LoadCustomersAsync());
            DeleteItemCommand = new Command<Customer>(async (cust) => await DeleteCustomerAsync(cust));
            AddCommand = new Command(async () => await ShowAddUpdateCustomerPopupAsync());
            UpdateItemCommand = new Command<Customer>(async (cust) => await ShowAddUpdateCustomerPopupAsync(cust));
        }
        #endregion

        #region Fields
        private readonly IApiService<Customer> _customerService;
        private ObservableCollection<Customer> _customers;
        private Customer _selectedCustomer;
        

        #endregion

        #region Propertes

        public ObservableCollection<Customer> Customers
        {
            get 
            {
                return _customers;
            }
            set { SetProperty(ref _customers, value); }
        } 

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set { SetProperty(ref _selectedCustomer, value);}
        }

        #endregion

        #region Commands
        public ICommand ShowDetails {get;}
        public ICommand AddCommand {get;}
        public ICommand DeleteItemCommand { get;}
        public ICommand UpdateItemCommand { get;}
        #endregion

        #region MesseangerControls
        public void OnAppearing()
        {
            MessagingCenter.Subscribe<CustomersPageViewModel, Customer>(
                this,
                "CustomerAdded",
                (sender, customer) => 
                {
                    Customers.Add(customer);
                }
            );
            MessagingCenter.Subscribe<AddCustomerPopupViewModel, Customer>(
                this,
                "CustomerUpdated",
                (sender, updatedCustomer) =>
            {
                var idx = Customers.IndexOf(
                    Customers.FirstOrDefault(c => c.CustomerId == updatedCustomer.CustomerId)
                );
                if (idx >= 0)
                {
                    Customers[idx] = updatedCustomer;
                }
            }
    );
        }

        public void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<CustomersPageViewModel, Customer>(this, "CustomerAdded");
            MessagingCenter.Unsubscribe<AddCustomerPopupViewModel, Customer>(this, "CustomerUpdated");
        }
        #endregion

        #region Methods
        private async Task LoadCustomersAsync()
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {
                var data = await _customerService.GetAllAsync();
                Customers.Clear();
                foreach (var c in data)
                {
                    Customers.Add(c);
                }
            }
            catch (Exception ex)
            {
                // obsługa błędów, np. Alert
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    $"Cannot load customers: {ex.Message}",
                    "OK"
                );
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task DeleteCustomerAsync(Customer customer)
        {
            if (customer == null) return;
            if (IsBusy) return;

            bool answer = await Application.Current.MainPage.DisplayAlert(
                "Confirm",
                $"Delete {customer.FirstName} {customer.LastName}?",
                "Yes", "No");

            if (!answer) return;

            IsBusy = true;
            try
            {
                bool deleted = await _customerService.DeleteAsync(customer.CustomerId);
                if (deleted)
                {
                    Customers.Remove(customer);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    $"Cannot delete the customer: {ex.Message}",
                    "OK"
                );
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ShowAddUpdateCustomerPopupAsync (Customer existingCustomer = null)
        {
            var popup = App.Services.GetService<AddCustomerPopup>();
            var popupVm = popup.BindingContext as AddCustomerPopupViewModel;

            if (existingCustomer == null)
            {
                popupVm.IsEditMode = false;
                popupVm.CurrentCustomer = new Customer();
            }
            else
            {
                popupVm.IsEditMode = true;
                popupVm.CurrentCustomer = new Customer
                {
                    CustomerId = existingCustomer.CustomerId,
                    FirstName = existingCustomer.FirstName,
                    LastName = existingCustomer.LastName,
                    Email = existingCustomer.Email,
                    Phone = existingCustomer.Phone,
                    Address = existingCustomer.Address,
                    City = existingCustomer.City,
                    PhotoPath = existingCustomer.PhotoPath
                };
            }
            await PopupNavigation.Instance.PushAsync(popup);
        }

        //private async Task ViewCustomerDetailsAsync(int id)
        //{
        //    if (IsBusy) return;
        //    IsBusy = true;

        //    try
        //    {
        //        var cust = await _customerService.GetByIdAsync(id);
        //        if (cust == null)
        //        {
        //            await Application.Current.MainPage.DisplayAlert("Info", "Customer not found.", "OK");
        //            return;
        //        }

        //        // Wyświetlamy w alert, lub otwieramy osobny widok z detalami
        //        await Application.Current.MainPage.DisplayAlert(
        //            "Customer Details",
        //            $"Name: {cust.FirstName} {cust.LastName}\nPhone: {cust.Phone}\nCity: {cust.City}",
        //            "OK"
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        await Application.Current.MainPage.DisplayAlert(
        //            "Error",
        //            $"Cannot load customer details: {ex.Message}",
        //            "OK"
        //        );
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}
        #endregion
    }
}
