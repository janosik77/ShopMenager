using ShopMenager.ViewModels.EmployeeVM;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.EmployeeV
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeesPage : ContentPage
    {
        public EmployeesPage()
        {
            InitializeComponent();
            try
            {
                BindingContext = App.Services.GetService<EmployeesViewModel>();
            }
            catch(Exception ex) { System.Diagnostics.Debug.WriteLine(ex); }
            
        }
    }
}