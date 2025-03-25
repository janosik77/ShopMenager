
using ShopMenager.ViewModels.CategoryVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ShopMenager.Views.CategoryV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage : ContentPage
    {
        public CategoriesPage()
        {
            InitializeComponent();
            BindingContext = App.Services.GetService<CategoriesViewModel>();
        }
    }
}