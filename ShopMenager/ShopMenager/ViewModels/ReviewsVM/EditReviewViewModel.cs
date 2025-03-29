using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System;
using System.Threading.Tasks;

namespace ShopMenager.ViewModels.ReviewsVM
{
    public class EditReviewViewModel : AUpdateItemViewModel<ReviewsDto>
    {
        public EditReviewViewModel(IDataStore<ReviewsDto> itemService) : base(itemService, "Edit Review")
        {
        }

        #region Fields

        private int _reviewID;
        private int _rating;
        private string _comments;
        private DateTime _reviewDate;
        private string _employeeName;
        private int _employeeID;
        private int _productID;
        private string _productName;

        #endregion

        #region Props

        public int ReviewID
        {
            get => _reviewID;
            set => SetProperty(ref _reviewID, value);
        }

        public int Rating
        {
            get => _rating;
            set => SetProperty(ref _rating, value);
        }

        public string Comments
        {
            get => _comments;
            set => SetProperty(ref _comments, value);
        }

        public DateTime ReviewDate
        {
            get => _reviewDate;
            set => SetProperty(ref _reviewDate, value);
        }

        public string EmployeeName
        {
            get => _employeeName;
            set => SetProperty(ref _employeeName, value);
        }

        public int EmployeeID
        {
            get => _employeeID;
            set => SetProperty(ref _employeeID, value);
        }

        public int ProductID
        {
            get => _productID;
            set => SetProperty(ref _productID, value);
        }

        public string ProductName
        {
            get => _productName;
            set => SetProperty(ref _productName, value);
        }

        #endregion

        public override async Task LoadItem(int id)
        {
            try
            {
                var review = await ItemService.GetItemAsync(id);
                if (review != null)
                {
                    ReviewID = review.ReviewID;
                    Rating = review.Rating;
                    Comments = review.Comments;
                    ReviewDate = review.ReviewDate;
                    EmployeeName = review.EmployeeName;
                    EmployeeID = review.EmployeeID;
                    ProductID = review.ProductID;
                    ProductName = review.ProductName;
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędu
            }
        }

        public override ReviewsDto SetItem() => new ReviewsDto
        {
            ReviewID = ReviewID,
            Rating = Rating,
            Comments = Comments,
            ReviewDate = ReviewDate,
            EmployeeName = EmployeeName,
            EmployeeID = EmployeeID,
            ProductID = ProductID,
            ProductName = ProductName
        };

        public override bool ValidateSave()
        {
            if (Rating < 1 || Rating > 5) return false;
            return true;
        }
    }
}
