using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.DiscountV;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.DiscountVM
{
    public class DicountViewModel : AListItemViewModel<Discounts>
    {
        public DicountViewModel(IDataStore<Discounts> itemService) : base(itemService, "Discounts")
        {
        }

        public override Task GoToAddPage() => Shell.Current.GoToAsync(nameof(AddDiscountView));

        public override async Task GoToDetailsPage(Discounts item) 
            => await Shell.Current
            .GoToAsync($"{nameof(DiscountDetailView)}?{nameof(DiscountsDetailsViewModel.ItemId)}={item.DiscountId}");
    }
}
