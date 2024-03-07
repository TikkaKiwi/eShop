using AutoMapper;
using eShop.UI.Http.Clients;

namespace eShop.UI.Admin.Services
{
    public class UIAdminService(CategoryHttpClient categoryHttp,
    ProductHttpClient productHttp, IMapper mapper)
    {
        List<CategoryGetDTO> Categories { get; set; } = [];
        public List<CarGetDTO> Products { get; private set; } = [];
        public List<LinkGroup> CaregoryLinkGroups { get; private set; } =
        [
            new LinkGroup
            {
                Name = "Categories"
            }
        ];

        public async Task GetLinkGroup()
        {
            Categories = await categoryHttp.GetCategoriesAsync();
            CaregoryLinkGroups[0].LinkOptions = mapper.Map<List<LinkOption>>(Categories);
            var linkOption = CaregoryLinkGroups[0].LinkOptions.FirstOrDefault();
            linkOption!.IsSelected = true;
        }

        public async Task GetProductsAsync() =>
            Products = await productHttp.GetProductsAsync();
    }
}
