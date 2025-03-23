using System.Threading.Tasks;

namespace ShopMenager.Services
{
    public interface INavigationService
    {
        Task NavigateTo<TViewModel>() where TViewModel : class;
        Task GoBack();
    }
}
