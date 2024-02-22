using Blazored.SessionStorage;

namespace eShop.UI.Storage.Services;

public class SessionStorage(ISessionStorageService sessionStorage)
    : IStorageService
{
    public async Task<T?> GetAsync<T>(string key) =>
        await sessionStorage.GetItemAsync<T>(key);

    public async Task RemoveAsync(string key) =>
        await sessionStorage.RemoveItemAsync(key);

    public async Task SetAsync<T>(string key, T value) =>
        await sessionStorage.SetItemAsync(key, value);
}