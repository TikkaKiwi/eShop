
using AutoMapper;
using eShop.Data.Context;
using Microsoft.EntityFrameworkCore;

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

    public async Task<TEntity> AddSync<TEntity, TDto>(TDto dto)
        where TEntity : class
        where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _db.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public async Task<bool> SaveChangesAsync() => await _db.SaveChangesAsync() >= 0;
}
