using eShop.API.DTO.DTOs;

namespace eShop.UI.Services;

public class UIService(CategoryHttpClient categoryHttp,
    ProductHttpClient productHttp, IMapper mapper)
{
    List<CategoryGetDTO> Categories { get; set; } = [];
    public List<CarGetDTO> Products { get; private set; } = [];
    public List<LinkGroup> CaregoryLinkGroups { get; private set; } =
    [
        new LinkGroup
        {
            Name = "Categories"
            /*,LinkOptions = new(){
                new LinkOption { Id = 1, Name = "Women", IsSelected = true },
                new LinkOption { Id = 2, Name = "Men", IsSelected = false },
                new LinkOption { Id = 3, Name = "Children", IsSelected = false }
            }*/
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

}