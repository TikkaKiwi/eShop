using AutoMapper;
using eShop.UI.Http.Clients;

namespace eShop.UI.Admin.Services
{
    public class UIAdminService(CategoryHttpClient categoryHttp,
    ProductHttpClient productHttp, IMapper mapper)
    {
        List<CategoryGetDTO> Categories { get; set; } = [];
        public List<CarGetDTO> Products { get; private set; } = [];
        public List<ModelGetDTO> Models { get; private set; } = [];
        public List<BrandGetDTO> Brands { get; private set; } = [];
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

        //Function to delete a product
        public async Task DeleteProductAsync(int id) =>
            await productHttp.DeleteProductAsync(id);

        //Function to edit a product
        public async Task EditProductAsync(CarPutDTO product) =>
            await productHttp.EditProductAsync(product);

        //Function to add a product
        public async Task AddProductAsync(CarPostDTO product) =>
            await productHttp.AddProductAsync(product);

        //Get all models 
        public async Task GetModelsAsync() =>
            Models = await productHttp.GetModelsAsync();

        public async Task GetBrandsAsync() =>
            Brands = await productHttp.GetBrandsAsync();
    }
}
