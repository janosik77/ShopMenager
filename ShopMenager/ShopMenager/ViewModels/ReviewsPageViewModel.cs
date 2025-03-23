using Rg.Plugins.Popup.Services;
using ShopMenager.Models;
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Popups;
using ShopMenager.Views.Popups;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

namespace ShopMenager.ViewModels
{
    public class ReviewsPageViewModel : BaseViewModel
    {
        #region Constructor
        public ReviewsPageViewModel
            (INavigationService navigationService,
            IApiService<Review> ReviewService) : base(navigationService)
        {
            Title = "Reviews";

            _ReviewService = ReviewService;
            Reviews = new ObservableCollection<Review>();

            Device.BeginInvokeOnMainThread(async () => await LoadReviewsAsync());
            DeleteItemCommand = new Command<Review>(async (rev) => await DeleteReviewAsync(rev));
            //AddCommand = new Command(async () => await ShowAddUpdateReviewPopupAsync());
            //UpdateItemCommand = new Command<Review>(async (rev) => await ShowAddUpdateReviewPopupAsync(rev));
        }
        #endregion

        #region Fields
        private readonly IApiService<Review> _ReviewService;
        private ObservableCollection<Review> _Reviews;
        private Review _selectedReview;


        #endregion

        #region Propertes

        public ObservableCollection<Review> Reviews
        {
            get
            {
                return _Reviews;
            }
            set { SetProperty(ref _Reviews, value); }
        }

        public Review SelectedReview
        {
            get => _selectedReview;
            set { SetProperty(ref _selectedReview, value); }
        }

        #endregion

        #region Commands
        public ICommand ShowDetails { get; }
        public ICommand AddCommand { get; }
        public ICommand DeleteItemCommand { get; }
        public ICommand UpdateItemCommand { get; }
        #endregion

        #region MesseangerControls
        public void OnAppearing()
        {
            MessagingCenter.Subscribe<ReviewsPageViewModel, Review>(
                this,
                "ReviewAdded",
                (sender, Review) =>
                {
                    Reviews.Add(Review);
                }
            );
            MessagingCenter.Subscribe<AddUpdateReviewPopioViewModel, Review>(
                this,
                "ReviewUpdated",
                (sender, updatedReview) =>
                {
                    var idx = Reviews.IndexOf(
                        Reviews.FirstOrDefault(c => c.ReviewID == updatedReview.ReviewID)
                    );
                    if (idx >= 0)
                    {
                        Reviews[idx] = updatedReview;
                    }
                }
    );
        }

        public void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<ReviewsPageViewModel, Review>(this, "ReviewAdded");
            MessagingCenter.Unsubscribe<AddUpdateReviewPopioViewModel, Review>(this, "ReviewUpdated");
        }
        #endregion

        #region Methods
        private async Task LoadReviewsAsync()
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {
                var data = await _ReviewService.GetAllAsync();
                Reviews.Clear();
                foreach (var c in data)
                {
                    Reviews.Add(c);
                }
            }
            catch (Exception ex)
            {
                // obsługa błędów, np. Alert
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    $"Cannot load Reviews: {ex.Message}",
                    "OK"
                );
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task DeleteReviewAsync(Review Review)
        {
            if (Review == null) return;
            if (IsBusy) return;

            bool answer = await Application.Current.MainPage.DisplayAlert(
                "Confirm",
                $"Delete Review id: {Review.ReviewID}?",
                "Yes", "No");

            if (!answer) return;

            IsBusy = true;
            try
            {
                bool deleted = await _ReviewService.DeleteAsync(Review.ReviewID);
                if (deleted)
                {
                    Reviews.Remove(Review);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    $"Cannot delete the Review: {ex.Message}",
                    "OK"
                );
            }
            finally
            {
                IsBusy = false;
            }
        }

        //private async Task ShowAddUpdateReviewPopupAsync(Review existingReview = null)
        //{
        //    var popup = App.Services.GetService<AddReviewPopup>();
        //    var popupVm = popup.BindingContext as AddReviewPopupViewModel;

        //    if (existingReview == null)
        //    {
        //        popupVm.IsEditMode = false;
        //        popupVm.CurrentReview = new Review();
        //    }
        //    else
        //    {
        //        popupVm.IsEditMode = true;
        //        popupVm.CurrentReview = new Review
        //        {
        //            ReviewId = existingReview.ReviewId,
        //            FirstName = existingReview.FirstName,
        //            LastName = existingReview.LastName,
        //            Email = existingReview.Email,
        //            Phone = existingReview.Phone,
        //            Address = existingReview.Address,
        //            City = existingReview.City,
        //            PhotoPath = existingReview.PhotoPath
        //        };
        //    }
        //    await PopupNavigation.Instance.PushAsync(popup);
        //}

        //private async Task ViewReviewDetailsAsync(int id)
        //{
        //    if (IsBusy) return;
        //    IsBusy = true;

        //    try
        //    {
        //        var cust = await _ReviewService.GetByIdAsync(id);
        //        if (cust == null)
        //        {
        //            await Application.Current.MainPage.DisplayAlert("Info", "Review not found.", "OK");
        //            return;
        //        }

        //        // Wyświetlamy w alert, lub otwieramy osobny widok z detalami
        //        await Application.Current.MainPage.DisplayAlert(
        //            "Review Details",
        //            $"Name: {cust.FirstName} {cust.LastName}\nPhone: {cust.Phone}\nCity: {cust.City}",
        //            "OK"
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        await Application.Current.MainPage.DisplayAlert(
        //            "Error",
        //            $"Cannot load Review details: {ex.Message}",
        //            "OK"
        //        );
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}
        #endregion
    }
}
