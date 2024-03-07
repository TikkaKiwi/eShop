using eShop.API.DTO.DTOs;
using eShop.UI.Storage.Services;
using System.ComponentModel;

namespace eShop.UI.Services;

public class UIService(CategoryHttpClient categoryHttp,
    ProductHttpClient productHttp, IMapper mapper, IStorageService storage)
{
    List<CategoryGetDTO> Categories { get; set; } = [];
    public List<CarGetDTO> Products { get; private set; } = [];
    public List<CartItemDTO> CartItems { get; set; } = [];
    public List<LinkGroup> CaregoryLinkGroups { get; private set; } =
    [
        new LinkGroup
        {
            Name = "Categories"
        }
    ];
    public int CurrentCategoryId { get; set; }

    public async Task GetLinkGroup()
    {
        Categories = await categoryHttp.GetCategoriesAsync();
        CaregoryLinkGroups[0].LinkOptions = mapper.Map<List<LinkOption>>(Categories);
        var linkOption = CaregoryLinkGroups[0].LinkOptions.FirstOrDefault();
        linkOption!.IsSelected = true;
    }

    public async Task OnCategoryLinkClick(int id)
    {
        CurrentCategoryId = id;
        await GetProductsAsync();
        CaregoryLinkGroups[0].LinkOptions.ForEach(l => l.IsSelected = false);
        CaregoryLinkGroups[0].LinkOptions.Single(l => l.Id.Equals(CurrentCategoryId)).IsSelected = true;
    }

    public async Task GetProductsAsync() =>
        Products = await productHttp.GetProductsAsync(CurrentCategoryId);

    public async Task<T> ReadStorage<T>(string key)// where T : class
    {
        //if (string.IsNullOrEmpty(key) || storage is null) return new T();
        return await storage.GetAsync<T>(key);
    }
    public async Task<T> ReadSingleStorage<T>(string key)// where T : class
    {
        return await storage.GetAsync<T>(key);
    }

    public async Task SaveToStorage<T>(string key, T value)// where T : class
    {
        if (string.IsNullOrEmpty(key) || storage is null) return;
        await storage.SetAsync<T>(key, value);
    }
    public async Task RemoveFromStorage(string key)// where T : class
    {
        if (string.IsNullOrEmpty(key) || storage is null) return;
        await storage.RemoveAsync(key);
    }
}