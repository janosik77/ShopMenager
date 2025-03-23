using ShopMenager.Models;
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.Abstract
{
    public class BaseViewModel<T> : INotifyPropertyChanged
    {
        #region Constructor
        public BaseViewModel(IApiService<T> itemService, INavigationService navigationService)
        {
            NavService = navigationService;
            ItemService = itemService;
        }
        #endregion

        #region Properties
        protected readonly IApiService<T> ItemService;
        protected readonly INavigationService NavService;
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        #endregion

        #region Helpers
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
