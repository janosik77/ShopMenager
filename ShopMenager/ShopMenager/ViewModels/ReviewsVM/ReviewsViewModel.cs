using ShopMenager.Services.ApiService;
using System.Threading.Tasks;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.ReviewV;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.ReviewsVM
{
    public class ReviewsViewModel : AListItemViewModel<ReviewsDto>
    {
        public ReviewsViewModel(IDataStore<ReviewsDto> itemService) : base(itemService, "Team Chat")
        {
        }

        public override Task GoToAddPage() => Shell.Current.GoToAsync(nameof(AddReviewView));

        public override async Task GoToDetailsPage(ReviewsDto item)
        => await Shell.Current.GoToAsync($"{nameof(ReviewdetailView)}?{nameof(ReviewDetailViewModel.ItemId)}={item.ReviewID}");
    }
}
