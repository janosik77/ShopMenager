using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;

namespace ShopMenager.ViewModels.CustomerVM
{
    public class AddCustomerViewModel : AAddItemViewModel<Customers>
    {
        public AddCustomerViewModel(IDataStore<Customers> itemService) : base(itemService, "New Customer")
        {
        }

        #region Properties
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _phone;
        public string Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }

        private string _address;
        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        private string _city;
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        private string _photoPath;
        public string PhotoPath
        {
            get => _photoPath;
            set => SetProperty(ref _photoPath, value);
        }

        #endregion

        public override Customers SetItem() => new Customers
        {
            FirstName = this.FirstName,
            LastName = this.LastName,
            Email = this.Email,
            Phone = this.Phone,
            Address = this.Address,
            City = this.City,
            PhotoPath = this.PhotoPath
        };

        public override bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(FirstName) &&
                   !string.IsNullOrWhiteSpace(LastName) &&
                   !string.IsNullOrWhiteSpace(Email);
        }
    }
}
