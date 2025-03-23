using ShopMenager.Models;
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System;
using System.Runtime.InteropServices.ComTypes;
namespace ShopMenager.ViewModels.DiscountVM
{
    public class AddDiscountsViewModel : AAddItemViewModel<Discount>
    {
        public AddDiscountsViewModel(IApiService<Discount> itemService, INavigationService navigationService, string title) : base(itemService, navigationService, title)
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
        }
        #region Properties

        private string _discountName;
        public string DiscountName
        {
            get => _discountName;
            set => SetProperty(ref _discountName, value);
        }

        private decimal _discountRate;
        public decimal DiscountRate
        {
            get => _discountRate;
            set => SetProperty(ref _discountRate, value);
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        #endregion

        public override Discount SetItem() => new Discount
        {
            DiscountName = DiscountName,
            DiscountRate = DiscountRate,
            StartDate = StartDate,
            EndDate = EndDate
        };

        public override bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(DiscountName)
            && DiscountRate > 0;
        }
    }
}
