using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.DiscountV;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.DiscountVM
{
    public class DiscountsDetailsViewModel : ADetailsItemViewModel<Discounts>
    {
        public DiscountsDetailsViewModel(IDataStore<Discounts> itemService) : base(itemService, "Discount Detail")
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
                var discount = await ItemService.GetItemAsync(id);
                if (discount != null)
                {
                    DiscountID = discount.DiscountId;
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

        protected override Task GoToUpdatePage()
            => Shell.Current.GoToAsync($"{nameof(EditDiscountView)}?{nameof(EditDiscountsViewModel.DiscountID)}={DiscountID}");
        protected override Task GoToUpdatePage(Discounts item)
        {
            return null;
        }
    }
}
