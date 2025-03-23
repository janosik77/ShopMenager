using ShopMenager.ViewModels;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeesPage : BasePage<EmployeesPageViewModel>
    {
        public EmployeesPage()
        {
            InitializeComponent();
        }
    }
}