using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopMenager.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync(string route);
        Task NavigateToAsync(string route, IDictionary<string, object> parameters);
        Task GoBack();
    }
}
