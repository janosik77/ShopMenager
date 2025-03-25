using ShopMenager.Services.ApiService;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.Abstract
{
    public abstract class AAddItemViewModel<T> : BaseViewModel<T> where T : class
    {
        protected AAddItemViewModel(IDataStore<T> itemService, string title) : base(itemService)
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
            await ItemService.AddItemAsync(SetItem());     /*CreateAsync(SetItem());*/
            await Shell.Current.GoToAsync("..");
        }
        #endregion
    }
}
