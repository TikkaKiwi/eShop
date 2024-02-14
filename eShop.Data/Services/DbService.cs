using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eShop.Data.Services;

public class DbService : IDbService
{
    private readonly EShopContext _db;
    private readonly IMapper _mapper;

    public DbService(EShopContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public virtual async Task<TDto> SingleAsync<TEntity, TDto>(int id)
        where TEntity : class, IEntity where TDto : class
    {
        var entity = await _db.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id);
        return _mapper.Map<TDto>(entity);
    }

    public virtual async Task<List<TDto>> GetAsync<TEntity, TDto>()
        where TEntity : class
        where TDto : class
    {
        var enteties = await _db.Set<TEntity>().ToListAsync();
        return _mapper.Map<List<TDto>>(enteties);
    }

    public IQueryable<TEntity> GetAsync<TEntity>(
    Expression<Func<TEntity, bool>> expression)
    where TEntity : class
    {
        return _db.Set<TEntity>().Where(expression);
    }

    public async Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
        where TEntity : class where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);

        await _db.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public async Task<bool> SaveChangesAsync() => await _db.SaveChangesAsync() >= 0;

    public void Update<TEntity, TDto>(TDto dto)
        where TEntity : class, IEntity where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);

        _db.Set<TEntity>().Update(entity);
    }

    public async Task<bool> DeleteAsync<TEntity>(int id)
        where TEntity : class, IEntity
    {
        try
        {
            var entity = await _db.Set<TEntity>()
                .SingleOrDefaultAsync(e => e.Id == id);

            if (entity is null)
                return false;

            _db.Remove(entity);
        }
        catch { return false; }

        return true;
    }

    public bool Delete<TEntity, TDto>(TDto dto) where TEntity : class where TDto : class
    {
        try
        {
            var entity = _mapper.Map<TEntity>(dto);
            if (entity is null) return false;
            _db.Remove(entity);
        }
        catch { return false; }

        return true;
    }

    public void IncludeNavigationsFor<TEntity>() where TEntity : class
    {
        var propertyNames = _db.Model.FindEntityType(typeof(TEntity))?.GetNavigations().Select(e => e.Name);
        var navigationPropertyNames = _db.Model.FindEntityType(typeof(TEntity))?.GetSkipNavigations().Select(e => e.Name);

        if (propertyNames is not null)
            foreach (var name in propertyNames)
                _db.Set<TEntity>().Include(name).Load();

        if (navigationPropertyNames is not null)
            foreach (var name in navigationPropertyNames)
                _db.Set<TEntity>().Include(name).Load();
    }
}
