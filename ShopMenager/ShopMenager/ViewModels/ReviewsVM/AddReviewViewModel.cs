
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System;


namespace ShopMenager.ViewModels.ReviewsVM
{
    public class AddReviewViewModel : AAddItemViewModel<Reviews>
    {
        public AddReviewViewModel(IDataStore<Reviews> itemService, string title) : base(itemService, title)
        {
            ReviewDate = DateTime.Now;
        }

        #region Properties

        private int _employeeID;
        public int EmployeeID
        {
            get => _employeeID;
            set => SetProperty(ref _employeeID, value);
        }

        private string _employeeName;
        public string EmployeeName
        {
            get => _employeeName;
            set => SetProperty(ref _employeeName, value);
        }

        private int _productID;
        public int ProductID
        {
            get => _productID;
            set => SetProperty(ref _productID, value);
        }

        private string _productName;
        public string ProductName
        {
            get => _productName;
            set => SetProperty(ref _productName, value);
        }

        private int _rating;
        public int Rating
        {
            get => _rating;
            set => SetProperty(ref _rating, value);
        }

        private string _comments;
        public string Comments
        {
            get => _comments;
            set => SetProperty(ref _comments, value);
        }

        private DateTime _reviewDate;
        public DateTime ReviewDate
        {
            get => _reviewDate;
            set => SetProperty(ref _reviewDate, value);
        }

        #endregion

        public override Reviews SetItem() => new Reviews
        {
            EmployeeID = EmployeeID,
            //EmployeeName = EmployeeName,
            ProductID = ProductID,
            //ProductName = ProductName,
            Rating = Rating,
            Comments = Comments,
            ReviewDate = ReviewDate
        };

        public override bool ValidateSave()
        {
            // Przykładowa walidacja
            return Rating >= 1 && Rating <= 5;
        }
    }
}
