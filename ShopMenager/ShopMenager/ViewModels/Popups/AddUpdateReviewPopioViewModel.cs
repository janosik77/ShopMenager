//using Rg.Plugins.Popup.Services;
//using ShopMenager.Models;
//using ShopMenager.Services.ApiService;
//using ShopMenager.Services;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Input;
//using Xamarin.Forms;

//namespace ShopMenager.ViewModels.Popups
//{
//    public class AddUpdateReviewPopioViewModel : BaseViewModel
//    {

//        #region Constructor
//        public AddUpdateReviewPopioViewModel(INavigationService navigationService, IApiService<Review> review) : base(navigationService)
//        {
//            _reviewService = review;
//            AddCommand = new Command(async () => await AddUpdateReviewAsync());
//            CancleCommand = new Command(async () => await PopupNavigation.Instance.PopAsync());
//        }
//        #endregion

//        #region Fields
//        private readonly IApiService<Review> _reviewService;
//        private bool _isEditMode;
//        private Review _currentReview;

//        #endregion

//        #region Properties
//        public string Header => IsEditMode ? "Edit Review" : "Add New review";
//        public string ActionButtonText => IsEditMode ? "Update" : "Add";
//        public bool IsEditMode
//        {
//            get => _isEditMode;
//            set
//            {
//                if (_isEditMode != value)
//                {
//                    _isEditMode = value;
//                    OnPropertyChanged();
//                    OnPropertyChanged(nameof(ActionButtonText));
//                    OnPropertyChanged(nameof(Header));
//                }
//            }
//        }
//        public Review CurrentReview
//        {
//            get => _currentReview;
//            set => SetProperty(ref _currentReview, value);
//        }
//        #endregion

//        #region Commands
//        public ICommand AddCommand { get; }
//        public ICommand CancleCommand { get; }
//        #endregion

//        #region methods
//        private async Task AddUpdateReviewAsync()
//        {

//            if (IsBusy) return;
//            if (CurrentReview == null) return;
//            try
//            {
//                IsBusy = true;
//                if (IsEditMode)
//                {

//                    bool success = await _reviewService.UpdateAsync(CurrentReview.ReviewID, CurrentReview);
//                    if (!success)
//                    {
//                        await Application.Current.MainPage.DisplayAlert("Error", "Update failed. Please try again.", "OK");
//                        return;
//                    }
//                    MessagingCenter.Send(this, "ReviewUpdated", CurrentReview);
//                }
//                else
//                {
//                    var created = await _reviewService.CreateAsync(CurrentReview);
//                    MessagingCenter.Send(this, "ReviewAdded", created);
//                }
//                await PopupNavigation.Instance.PopAsync();
//            }
//            catch (Exception ex)
//            {
//                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
//            }
//            finally
//            {
//                IsBusy = false;
//            }
//        }
//        #endregion
//    }
//}
