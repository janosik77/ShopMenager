
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.EmployeeV;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.EmployeeVM
{
    public class EmployeesViewModel : AListItemViewModel<EmployeeDto>
    {
        public EmployeesViewModel(IDataStore<EmployeeDto> itemService) : base(itemService, "Employees")
        {
        }

        public override Task GoToAddPage() => Shell.Current.GoToAsync(nameof(AddEmployeeView));

        public override async Task GoToDetailsPage(EmployeeDto item) 
            => await Shell.Current
            .GoToAsync($"{nameof(EmployeeDetailsView)}?{nameof(EmployeeDetailViewModel.ItemId)}={item.EmployeeID}");
    }
}
