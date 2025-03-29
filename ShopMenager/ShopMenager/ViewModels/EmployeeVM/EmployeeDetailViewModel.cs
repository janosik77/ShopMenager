using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.EmployeeV;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.EmployeeVM
{
    public class EmployeeDetailViewModel : ADetailsItemViewModel<EmployeeDto>
    {
        public EmployeeDetailViewModel(IDataStore<EmployeeDto> itemService) : base(itemService, "Employee Detail")
        {
        }

        #region Fields
        private int _employeeID;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        private DateTime _hireDate;
        private decimal _salary;
        private string _photoPath;
        #endregion

        #region Props
        public int EmployeeID
        {
            get => _employeeID;
            set => SetProperty(ref _employeeID, value);
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

        public DateTime HireDate
        {
            get => _hireDate;
            set => SetProperty(ref _hireDate, value);
        }

        public decimal Salary
        {
            get => _salary;
            set => SetProperty(ref _salary, value);
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
                var employee = await ItemService.GetItemAsync(id);
                if (employee != null)
                {
                    EmployeeID = employee.EmployeeID;
                    FirstName = employee.FirstName;
                    LastName = employee.LastName;
                    Email = employee.Email;
                    Phone = employee.Phone;
                    HireDate = employee.HireDate;
                    Salary = employee.Salary;
                    PhotoPath = employee.PhotoPath;
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędu
            }
        }

        protected override Task GoToUpdatePage()
            => Shell.Current.GoToAsync($"{nameof(EditEmployeeView)}?{nameof(EditEmployeeViewModel.EmployeeID)}={EmployeeID}");
        protected override Task GoToUpdatePage(EmployeeDto item)
        {
            return null;
        }
    }
}
