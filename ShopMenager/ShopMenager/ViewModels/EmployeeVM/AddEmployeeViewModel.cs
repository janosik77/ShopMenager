
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System;

namespace ShopMenager.ViewModels.EmployeeVM
{
    public class AddEmployeeViewModel : AAddItemViewModel<EmployeeDto>
    {
        public AddEmployeeViewModel(IDataStore<EmployeeDto> itemService) : base(itemService, "Create Employee")
        {
            HireDate = DateTime.Now;
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

        private DateTime _hireDate;
        public DateTime HireDate
        {
            get => _hireDate;
            set => SetProperty(ref _hireDate, value);
        }

        private decimal _salary;
        public decimal Salary
        {
            get => _salary;
            set => SetProperty(ref _salary, value);
        }

        private string _photoPath;
        public string PhotoPath
        {
            get => _photoPath;
            set => SetProperty(ref _photoPath, value);
        }

        #endregion

        public override EmployeeDto SetItem() => new EmployeeDto
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Phone = Phone,
            HireDate = HireDate,
            Salary = Salary,
            PhotoPath = PhotoPath
        };

        public override bool ValidateSave()
        {
            // Przykładowa walidacja
            return !string.IsNullOrWhiteSpace(FirstName)
                && !string.IsNullOrWhiteSpace(LastName);
        }
    }
}
