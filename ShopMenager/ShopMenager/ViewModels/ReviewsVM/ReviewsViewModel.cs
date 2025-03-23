
using ShopMenager.Models;
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using System.Threading.Tasks;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.ReviewV;

namespace ShopMenager.ViewModels.ReviewsVM
{
    public class ReviewsViewModel : AListItemViewModel<Review>
    {
        public ReviewsViewModel(IApiService<Review> itemService, INavigationService navigationService, string title) : base(itemService, navigationService, title)
        {
        }

        public override Task GoToAddPage() => NavService.NavigateToAsync(nameof(AddReviewView));

        public override async Task GoToDetailsPage(Review item)
        => await NavService.NavigateToAsync($"{nameof(ReviewdetailView)}?{nameof(ReviewDetailViewModel.ItemId)}={item.ReviewID}");
    }
}
