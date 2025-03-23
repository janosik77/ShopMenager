using ShopMenager.ViewModels;
using ShopMenager.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace ShopMenager.Services
{
    public class NavigationService : INavigationService
    {
        public async Task GoBack()
        {
            await Shell.Current.Navigation.PopAsync();
        }

        public async Task NavigateTo<TViewModel>() where TViewModel : class
        {
            var page = GetPageFromView(typeof(TViewModel));
            if (page == null)
            {
                await Shell.Current.Navigation.PushAsync(page);
            }
        }

        private Page GetPageFromView(Type viewModelType) 
        {
            if (viewModelType == typeof(HomePageViewModel))
                return App.Services.GetService<HomePage>();
            if (viewModelType == typeof(DiscountsPageViewModel))
                return App.Services.GetService<DiscountsPage>();
            return null;
        }
    }
}
