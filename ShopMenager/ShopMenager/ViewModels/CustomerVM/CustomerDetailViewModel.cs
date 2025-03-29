using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System;
using System.Threading.Tasks;
using ShopMenager.Views.CustomerV;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.CustomerVM
{
    public class CustomerDetailViewModel : ADetailsItemViewModel<CustomerDto>
    {
        public CustomerDetailViewModel(IDataStore<CustomerDto> itemService) : base(itemService, "Customer Detail")
        {
        }

        #region Fields
        private int _customerId;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        private string _address;
        private string _city;
        private string _photoPath;
        #endregion

        #region Props
        public int CustomerId
        {
            get => _customerId;
            set => SetProperty(ref _customerId, value);
        }

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }

        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        public string PhotoPath
        {
            get => _photoPath;
            set => SetProperty(ref _photoPath, value);
        }
        #endregion


        public override async Task LoadItem(int id)
        {
            try
            {
                var customer = await ItemService.GetItemAsync(id);
                if (customer != null)
                {
                    CustomerId = customer.CustomerId;
                    FirstName = customer.FirstName;
                    LastName = customer.LastName;
                    Email = customer.Email;
                    Phone = customer.Phone;
                    Address = customer.Address;
                    City = customer.City;
                    PhotoPath = customer.PhotoPath;
                }
                else
                {
                    // Obsługa przypadku, gdy nie znaleziono obiektu
                    // np. wyświetlenie komunikatu lub cofnięcie na poprzednią stronę
                }
            }
            catch (Exception ex)
            {
                // Obsługa wyjątków, np. logowanie błędu
            }
        }

        protected override async Task GoToUpdatePage(CustomerDto item) 
            => await Shell.Current
            .GoToAsync($"{nameof(EditCustomerViwe)}?{nameof(EditCustomerViewModel.ItemId)}={item.CustomerId}");
        protected override async Task GoToUpdatePage() 
            => await Shell.Current
            .GoToAsync($"{nameof(EditCustomerViwe)}?{nameof(EditCustomerViewModel.ItemId)}={CustomerId}");
    }
}
