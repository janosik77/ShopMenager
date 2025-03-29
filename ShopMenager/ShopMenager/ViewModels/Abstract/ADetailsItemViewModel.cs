
using ShopMenager.Services.ApiService;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.Abstract
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public abstract class ADetailsItemViewModel<T> : BaseViewModel<T> where T : class
    {
        protected ADetailsItemViewModel(IDataStore<T> itemService, string title) : base(itemService)
        {
            Title = title;
            CancelCommand = new Command(OnCancel);
            DeleteCommand = new Command(OnDelete);
            UpdateCommand = new Command(OnUpdate);
        }

        #region Fields
        private int _itemId;
        public int ItemId
        {
            get
            {
                return _itemId;
            }
            set
            {
                if (SetProperty(ref _itemId, value))
                {
                    // Fire-and-forget
                    _ = LoadItem(value);
                }
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
            => await Shell.Current.GoToAsync("..");
        private async void OnDelete()
        {
            await ItemService.DeleteItemAsync(ItemId);
            await Shell.Current.GoToAsync("..");
        }
        private async void OnUpdate()
            => await GoToUpdatePage();
        protected abstract Task GoToUpdatePage(T item);
        protected abstract Task GoToUpdatePage();
        public abstract Task LoadItem(int id);
        #endregion
    }
}
