namespace eShop.Data.Services;

public class CategoryDbService(EShopContext db, IMapper mapper) 
    : DbService(db, mapper)
{
    public virtual async Task<List<TDto>> GetAsync<TEntity, TDto>()
        where TEntity : class
        where TDto : class
    {
        return await base.GetAsync<TEntity, TDto>();
    }
}
