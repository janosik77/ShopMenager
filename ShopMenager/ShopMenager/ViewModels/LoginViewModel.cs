using Microsoft.Extensions.DependencyInjection;
using ShopMenager.Services.Interfaces;
using ShopMenager.Services.SessionMngr;
using ShopMenager.ViewModels.Abstract;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShopMenager.ViewModels
{
    public class LoginViewModel : BaseViewModel<LoginRequestDto>
    {
        public LoginViewModel(IAuthService auth):base()
        { 
            _auth = auth; 
            LoginCommand = new Command(async () => await Login()); 
        }

        #region Prop
        private readonly IAuthService _auth;
        private string _username;
        public string UserName
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }
        string _password;
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }
        #endregion

        private async Task Login()
        {
            IsBusy = true;
            try
            {
                var dto = await _auth.LoginAsync(new LoginRequestDto { Username = UserName, Password = Password });
                await SessionManager.SaveTokenAsync(dto.AccessToken, dto.ExpiresAt);
                Application.Current.MainPage = App.Services.GetRequiredService<AppShell>();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                      .DisplayAlert("Błąd logowania",
                                    ex.Message, "OK");
            }
            finally { IsBusy = false; }
        }
    }
}
