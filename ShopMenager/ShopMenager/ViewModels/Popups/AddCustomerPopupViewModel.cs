//using Rg.Plugins.Popup.Services;
//using ShopMenager.Models;
//using ShopMenager.Services;
//using ShopMenager.Services.ApiService;
//using System;
//using System.Threading.Tasks;
//using System.Windows.Input;
//using Xamarin.Forms;

//namespace ShopMenager.ViewModels.Popups
//{
//    public class AddCustomerPopupViewModel : BaseViewModel
//    {
        
//        #region Constructor
//        public AddCustomerPopupViewModel(INavigationService navigationService, IApiService<Customer> customer) : base(navigationService)
//        {
//            _customerService = customer;
//            AddCommand = new Command(async () => await AddUpdateCustomerAsync());
//            CancleCommand = new Command(async () => await PopupNavigation.Instance.PopAsync());
//        }
//        #endregion

//        #region Fields
//        private readonly IApiService<Customer> _customerService;      
//        private bool _isEditMode;
//        private Customer _currentCustomer;

//        #endregion

//        #region Properties
//        public string Header => IsEditMode ? "Edit Customer" : "Add New Customer";
//        public string ActionButtonText => IsEditMode ? "Update" : "Add";
//        public bool IsEditMode
//        {
//            get => _isEditMode;
//            set
//            {
//                if (_isEditMode != value)
//                {
//                    _isEditMode = value;
//                    OnPropertyChanged();
//                    OnPropertyChanged(nameof(ActionButtonText));
//                    OnPropertyChanged(nameof(Header));
//                }
//            }
//        }
//        public Customer CurrentCustomer
//        {
//            get => _currentCustomer;
//            set => SetProperty(ref _currentCustomer, value);
//        }
//        #endregion

//        #region Commands
//        public ICommand AddCommand { get; }
//        public ICommand CancleCommand { get; }
//        #endregion

//        #region methods
//        private async Task AddUpdateCustomerAsync()
//        {

//            if (IsBusy) return;
//            if (CurrentCustomer == null) return;
//            try
//            {
//                IsBusy = true; 
//                if (IsEditMode)
//                {

//                    bool success = await _customerService.UpdateAsync(CurrentCustomer.CustomerId, CurrentCustomer);
//                    if (!success)
//                    {
//                        await Application.Current.MainPage.DisplayAlert("Error", "Update failed. Please try again.", "OK");
//                        return;
//                    }
//                    MessagingCenter.Send(this, "CustomerUpdated", CurrentCustomer);
//                }
//                else
//                {
//                    var created = await _customerService.CreateAsync(CurrentCustomer);
//                    MessagingCenter.Send(this, "CustomerAdded", created);
//                }
//                await PopupNavigation.Instance.PopAsync();
//            }
//            catch (Exception ex)
//            {
//                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
//            }
//            finally
//            {
//                IsBusy = false;
//            }  
//        }
//        #endregion

//    }
//}

