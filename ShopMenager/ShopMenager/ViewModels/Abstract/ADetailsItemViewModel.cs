
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.Abstract
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public abstract class ADetailsItemViewModel<T> : BaseViewModel<T> where T : class
    {
        protected ADetailsItemViewModel(IApiService<T> itemService, INavigationService navigationService,string title) : base(itemService, navigationService)
        {
            Title = title;
            CancelCommand = new Command(OnCancel);
            DeleteCommand = new Command(OnDelete);
            UpdateCommand = new Command(OnUpdate);
        }

        #region Fields
        private int itemId;
        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItem(value).GetAwaiter().GetResult();
            }
        }
        #endregion

        #region Commands
        public Command CancelCommand { get; }
        public Command DeleteCommand { get; }
        public Command UpdateCommand { get; }
        #endregion

        #region Methodds
        private async void OnCancel()
            => await NavService.NavigateToAsync("..");
        private async void OnDelete()
        {
            await ItemService.DeleteAsync(ItemId);
            await Shell.Current.GoToAsync("..");
        }
        private async void OnUpdate()
            => await GoToUpdatePage();
        protected abstract Task GoToUpdatePage();
        public abstract Task LoadItem(int id);
        #endregion
    }
}
