using System.Xml.Linq;
using Microsoft.JSInterop;

namespace Blucrow.Foodtracker.Services
{
    public class IndexedDbAccessor
    {
        private readonly IJSRuntime _jsRuntime;

        public IndexedDbAccessor(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<bool> SaveData<T>(string key, T obj)
        {
            var jsonData = System.Text.Json.JsonSerializer.Serialize<T>(obj);
            var success = await _jsRuntime.InvokeAsync<bool>("indexedDbHelper.addObject", key, jsonData);
            return success;
        }

        public async Task<T?> LoadData<T>(string key) where T : class
        {
            var loadedJson = await _jsRuntime.InvokeAsync<string>("indexedDbHelper.getObject", key);
            if (!string.IsNullOrEmpty(loadedJson))
            {
                return System.Text.Json.JsonSerializer.Deserialize<T>(loadedJson);
            }
            else
                return null;
        }


        public async Task<bool> DeleteData(string key)
        {
            var success = await _jsRuntime.InvokeAsync<bool>("indexedDbHelper.deleteObject", key);
            return success;
        }
    }
}
