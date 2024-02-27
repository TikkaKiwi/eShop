
using eShop.API.DTO;
using eShop.API.DTO.DTOs;
using eShop.Data.Enteties;

namespace eShop.Data.Services;

public class ProductDbService(EShopContext db, IMapper mapper) : DbService(db, mapper)
{
    public async Task<List<CarGetDTO>> GetProductsByCategoryAsync(int categoryId)
    {
        IncludeNavigationsFor<Colour>();
        IncludeNavigationsFor<Brand>();
        IncludeNavigationsFor<Fuel>();

        var productIds = GetAsync<CarCategory>(pc => pc.CategoryId.Equals(categoryId))
            .Select(pc => pc.CarId);
        var products = await GetAsync<Car>(p => productIds.Contains(p.Id)).ToListAsync();

        return MapList<Car, CarGetDTO>(products);
    }
    public List<TDto> MapList<TEntity, TDto>(List<TEntity> entities)
    where TEntity : class
    where TDto : class
    {
        return mapper.Map<List<TDto>>(entities);
    }
}
