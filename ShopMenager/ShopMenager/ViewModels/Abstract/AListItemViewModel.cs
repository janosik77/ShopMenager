using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.Abstract
{
    public abstract class AListItemViewModel<T> : BaseViewModel<T> where T : class
    {
        public AListItemViewModel(IApiService<T> itemService, INavigationService navigationService, string title) : base(itemService, navigationService)
        {
            Title = title;
            Items = new ObservableCollection<T>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<T>(OnItemSelected);
            AddCommand = new Command(OnAddItem);
        }

        #region Fields
        private T _selectedItem;
        #endregion

        #region Properties
        public ObservableCollection<T> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddCommand { get; }
        public Command<T> ItemTapped { get; }
        public T SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
        #endregion

        #region Methods
        async Task ExecuteLoadItemsCommand()
        {
            if (!IsBusy) 
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await ItemService.GetAllAsync();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    $"Cannot load customers: {ex.Message}",
                    "OK"
                );
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = default(T);
        }
        private async void OnAddItem(object obj)
            => await GoToAddPage();
        public abstract Task GoToAddPage();
        public abstract Task GoToDetailsPage(T item);
        async void OnItemSelected(T item)
        {
            if (item == null)
                return;
            await GoToDetailsPage(item);
        }
        #endregion
    }
}
