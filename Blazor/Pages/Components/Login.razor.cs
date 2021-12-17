using System;
using System.Threading.Tasks;
using Blazor.Data.Implementation;

namespace Blazor.Pages.Components
{
    public partial class Login
    {
        private string _username;
        private string _password;
        private string _errorMessage;

        public async Task PerformLogin()
        {
            _errorMessage = "";
            try
            {
                await ((CustomAuthenticationStateProvider) AuthenticationStateProvider).ValidateLogin(_username, _password);
                _username = "";
                _password = "";
                NavigationManager.NavigateTo("/");
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
            }
        }

        public async Task PerformLogout()
        {
            _errorMessage = "";
            _username = "";
            _password = "";
            try
            {
                ((CustomAuthenticationStateProvider) AuthenticationStateProvider).Logout();
                NavigationManager.NavigateTo("/");
            }
            catch (Exception e)
            {
            }
        }
    }
}