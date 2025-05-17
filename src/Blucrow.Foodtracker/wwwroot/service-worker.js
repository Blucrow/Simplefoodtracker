// In development, always fetch from the network and do not enable offline support.
// This is because caching would make development more difficult (changes would not
// be reflected on the first load after each change).
self.addEventListener('fetch', () => { });
navigator.serviceWorker.register('/Simplefoodtracker/wwwroot/service-worker.js', {
    scope: '/Simplefoodtracker/'
}).then(registration => {
    console.log('Service worker registered with scope:', registration.scope);
}).catch(error => {
    console.error('Service worker registration failed:', error);
});
