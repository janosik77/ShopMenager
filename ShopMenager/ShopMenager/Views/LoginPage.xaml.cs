using ShopMenager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = App.Services.GetService<LoginViewModel>();
        }
    }
}