using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace ShopMenager.Views
{
    public class BasePage<TViewModel> : ContentPage where TViewModel : class
    {
        public BasePage()
        {
            BindingContext = App.Services.GetService<TViewModel>();
        }
    }
}
