using ShopMenager.ViewModels.EmployeeVM;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.EmployeeV
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeesPage : BasePage<EmployeesViewModel>
    {
        public EmployeesPage()
        {
            InitializeComponent();
        }
    }
}