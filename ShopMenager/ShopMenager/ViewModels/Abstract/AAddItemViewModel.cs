using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.Abstract
{
    public abstract class AAddItemViewModel<T> : BaseViewModel<T> where T : class
    {
        protected AAddItemViewModel(IApiService<T> itemService, INavigationService navigationService, string title) : base(itemService, navigationService)
        {
            Title = title;
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        #region Commands
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        #endregion

        #region Methods
        public abstract bool ValidateSave();
        private async void OnCancel()
            => await Shell.Current.GoToAsync("..");
        public abstract T SetItem();
        private async void OnSave()
        {
            await ItemService.CreateAsync(SetItem());
            await Shell.Current.GoToAsync("..");
        }
        #endregion
    }
}
