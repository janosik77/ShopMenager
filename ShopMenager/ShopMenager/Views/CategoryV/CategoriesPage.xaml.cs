using ShopMenager.ViewModels;
using ShopMenager.ViewModels.CategoryVM;
using Xamarin.Forms.Xaml;


namespace ShopMenager.Views.CategoryV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage : BasePage<CategoriesViewModel>
    {
        public CategoriesPage()
        {
            InitializeComponent();
        }
    }
}