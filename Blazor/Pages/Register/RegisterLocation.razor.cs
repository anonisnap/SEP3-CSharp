using System.Threading.Tasks;
using Entities.Models;

namespace Blazor.Pages.Register
{
    public partial class RegisterLocation
    {
        private Location _location;

        protected override async Task OnInitializedAsync()
        {
            _location = new();
        }

        private void RegisterNewLocation()
        {
            _locationHandler.RegisterAsync(_location);
            _navigationManager.NavigateTo("/RegisteredLocations");
        }
    }
}