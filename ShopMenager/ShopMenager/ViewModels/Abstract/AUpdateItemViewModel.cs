using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.Abstract
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public abstract class AUpdateItemViewModel<T> : BaseViewModel<T> where T : class
    {
        protected AUpdateItemViewModel(IDataStore<T> itemService, string title) : base(itemService)
        {
            Title = title;
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        #region Fields
        private int itemId;
        #endregion

        #region Properties
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
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        #endregion

        #region Methods
        public abstract bool ValidateSave();
        private async void OnCancel()
            => await Shell.Current.GoToAsync("..");
        public abstract T SetItem();
        public abstract Task LoadItem(int id);
        private async void OnSave()
        {
            //await ItemService.UpdateAsync(SetItem());
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        #endregion
    }
}
