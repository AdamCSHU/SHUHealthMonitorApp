using Blazored.SessionStorage;
using System.Text;
using System.Text.Json;

namespace SHUHealthApp.Client.Extensions
{
    //class needed folr session storage encryption, encrypts session storage in base 64 format. 
    public static class SessionStorageService
    {
        public static async Task SaveitemEncrypted<T>(this ISessionStorageService sessionStorageService, string key, T item)
        {
            var JsonItem = JsonSerializer.Serialize(item);
            var JsonItemBytes = Encoding.UTF8.GetBytes(JsonItem);
            var JsonBase64 = Convert.ToBase64String(JsonItemBytes);
            await sessionStorageService.SetItemAsync(key, JsonBase64);
        }

        public static async Task<T> ReadItemEncrypted<T>(this ISessionStorageService sessionStorageService, string key)
        {
            var JsonBase64 = await sessionStorageService.GetItemAsync<string>(key);
            var JsonItemBytes = Convert.FromBase64String(JsonBase64);
            var JsonBase64Bytes = Encoding.UTF8.GetBytes(JsonBase64);
            var item = JsonSerializer.Deserialize<T>(JsonBase64Bytes);
            return item;
        }
    }
}
