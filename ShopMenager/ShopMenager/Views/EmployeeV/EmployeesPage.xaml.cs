using ShopMenager.ViewModels.EmployeeVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.EmployeeV
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeesPage : ContentPage
    {
        EmployeesViewModel _viewModel;
        public EmployeesPage()

        {
            InitializeComponent();

            BindingContext = _viewModel = App.Services.GetService<EmployeesViewModel>();
            
            
        }

        protected override void OnAppearing()
        {
            //base.OnAppearing();
            _viewModel.OnAppearing();

        }
    }
}