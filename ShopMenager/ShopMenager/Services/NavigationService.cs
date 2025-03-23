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

        public async Task NavigateToAsync(string route)
        {
            await Shell.Current.GoToAsync(route);
        }

        public async Task NavigateToAsync(string route, IDictionary<string, object> parameters)
        {
            if (parameters != null && parameters.Count > 0)
            {
                var queryString = "?";
                foreach (var kvp in parameters)
                {
                    queryString += $"{kvp.Key}={kvp.Value}&";
                }
                queryString = queryString.TrimEnd('&');
                route += queryString;
            }

            await Shell.Current.GoToAsync(route);
        }
    }
}
