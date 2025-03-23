using ShopMenager.ViewModels;
using Xamarin.Forms.Xaml;


namespace ShopMenager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage : BasePage<CategoriesPageViewModel>
    {
        public CategoriesPage()
        {
            InitializeComponent();
        }
    }
}