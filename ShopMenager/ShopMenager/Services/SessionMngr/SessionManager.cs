using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ShopMenager.Services.SessionMngr
{
    public static class SessionManager
    {
        const string Key_Access = "access_token";
        const string Key_Expires = "access_expires";

        public async static Task SaveTokenAsync(string token, DateTime expiresAt)
        {
            await SecureStorage.SetAsync(Key_Access, token);
            await SecureStorage.SetAsync(Key_Expires, expiresAt.ToString("O"));
        }

        public static Task<string> GetTokenAsync()
            => SecureStorage.GetAsync(Key_Access);

        public static bool IsLoggedIn =>
            !string.IsNullOrWhiteSpace(
                SecureStorage.GetAsync(Key_Access).GetAwaiter().GetResult());
        public static Task LogoutAsync()
        {
            SecureStorage.Remove(Key_Access);
            SecureStorage.Remove(Key_Expires);
            return Task.CompletedTask;
        }
    }
}
