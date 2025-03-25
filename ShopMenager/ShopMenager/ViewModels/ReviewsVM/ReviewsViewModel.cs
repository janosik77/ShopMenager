using ShopMenager.Services.ApiService;
using System.Threading.Tasks;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.ReviewV;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.ReviewsVM
{
    public class ReviewsViewModel : AListItemViewModel<Reviews>
    {
        public ReviewsViewModel(IDataStore<Reviews> itemService) : base(itemService, "Reviews")
        {
        }

        public override Task GoToAddPage() => Shell.Current.GoToAsync(nameof(AddReviewView));

        public override async Task GoToDetailsPage(Reviews item)
        => await Shell.Current.GoToAsync($"{nameof(ReviewdetailView)}?{nameof(ReviewDetailViewModel.ItemId)}={item.ReviewID}");
    }
}
