using ShopMenager.Models;
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using System;
using System.Threading.Tasks;

namespace ShopMenager.ViewModels.DiscountVM
{
    public class EditDiscountsViewModel : AUpdateItemViewModel<Discount>
    {
        public EditDiscountsViewModel(IApiService<Discount> itemService, INavigationService navigationService) : base(itemService, navigationService, "Edit Discount")
        {
        }
        #region Fields

        private int _discountID;
        private string _discountName;
        private decimal _discountRate;
        private DateTime _startDate;
        private DateTime _endDate;

        #endregion

        #region Props

        public int DiscountID
        {
            get => _discountID;
            set => SetProperty(ref _discountID, value);
        }

        public string DiscountName
        {
            get => _discountName;
            set => SetProperty(ref _discountName, value);
        }

        public decimal DiscountRate
        {
            get => _discountRate;
            set => SetProperty(ref _discountRate, value);
        }

        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        #endregion

        public override async Task LoadItem(int id)
        {
            try
            {
                var discount = await ItemService.GetByIdAsync(id);
                if (discount != null)
                {
                    DiscountID = discount.DiscountID;
                    DiscountName = discount.DiscountName;
                    DiscountRate = discount.DiscountRate;
                    StartDate = discount.StartDate;
                    EndDate = discount.EndDate;
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędu
            }
        }

        public override Discount SetItem() => new Discount
        {
            DiscountID = DiscountID,
            DiscountName = DiscountName,
            DiscountRate = DiscountRate,
            StartDate = StartDate,
            EndDate = EndDate
        };

        public override bool ValidateSave()
        {
            if (string.IsNullOrWhiteSpace(DiscountName)) return false;
            if (DiscountRate <= 0) return false;
            return true;
        }
    }
}
