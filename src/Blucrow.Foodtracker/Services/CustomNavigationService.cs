using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Blucrow.Foodtracker.Services
{
    public class CustomNavigationService
    {
        private readonly NavigationManager _navigationManager;
        private string _basePath;
        public CustomNavigationService(NavigationManager navigationManager, BasePathHelper basePathHelper)
        {
            _navigationManager = navigationManager;
            _basePath = basePathHelper.BasePath;
        }

        public void NavigateTo(string uri, bool forceLoad = false, bool replace = false)
        {
            _navigationManager.NavigateTo(_basePath + uri, forceLoad, replace);
        }

        // You can also expose other methods from NavigationManager if needed
        public string Uri => _navigationManager.Uri;
        public string BaseUri => _navigationManager.BaseUri;
        public event EventHandler<LocationChangedEventArgs> LocationChanged
        {
            add => _navigationManager.LocationChanged += value;
            remove => _navigationManager.LocationChanged -= value;
        }
    }
}
