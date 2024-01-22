namespace eShop.Data.Services;

public interface IDbService
{
    Task<List<TDto>> GetAsync<TEntity, TDto>()
    where TEntity : class
    where TDto : class;

    Task<TDto> SingleAsync<TEntity, TDto>(int id)
        where TEntity : class, IEntity
        where TDto : class;

    Task<TEntity> AddSync<TEntity, TDto>(TDto tdto)
        where TEntity : class
        where TDto : class;

    Task<bool> SaveChangesAsync();
}
