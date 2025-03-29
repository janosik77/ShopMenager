
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System;
namespace ShopMenager.ViewModels.DiscountVM
{
    public class AddDiscountsViewModel : AAddItemViewModel<Discounts>
    {
        public AddDiscountsViewModel(IDataStore<Discounts> itemService) : base(itemService, "Discounts")
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

        public override Discounts SetItem() => new Discounts
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
