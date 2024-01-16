namespace eShop.Data.Services;

public interface IDbService
{
    Task<List<TDto>> GetAsync<TEntity, TDto>()
    where TEntity : class
    where TDto : class;
}
