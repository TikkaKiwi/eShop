using System.Linq.Expressions;

namespace eShop.API.Extensions.Extensions;

public static class HttpExtensions
{
    public static void AddEndPoint<TEntity, TPostDto, TPutDto, TGetDto>(this WebApplication app) 
        where TEntity : class, IEntity where TPostDto : class where TPutDto : class where TGetDto : class
    {
        var node = typeof(TEntity).Name.ToLower();
        
        app.MapGet($"/api/{node}s/" + "{id}", HttpSingleAsync<TEntity, TGetDto>);
        app.MapGet($"/api/{node}s", HttpGetAsync<TEntity, TGetDto>);
        app.MapPost($"/api/{node}s", HttpPostAsync<TEntity, TPostDto>);
        //app.MapPut($"/api/{node}s/" + "{id}", HttpPutAsync<TEntity, TPutDto>);
        //app.MapDelete($"/api/{node}s/" + "{id}", HttpDeleteAsync<TEntity>);
        
    }

    public static async Task<IResult> HttpSingleAsync<TEntity, TDto>(this IDbService db, int id)
        where TEntity : class, IEntity where TDto : class
    {
        var result = await db.SingleAsync<TEntity, TDto>(id);
        if (result is null) 
            return Results.NotFound();

        return Results.Ok(result);
    }

    public static async Task<IResult> HttpGetAsync<TEntity, TDto>(this IDbService db) 
        where TEntity : class where TDto : class => 
        Results.Ok(await db.GetAsync<TEntity, TDto>());

    public static async Task<IResult> HttpPostAsync<TEntity, TPostDto>(this IDbService db, TPostDto dto)
        where TEntity : class, IEntity where TPostDto : class
    {
        try
        {
            var entity = await db.AddSync<TEntity, TPostDto>(dto);
            if(await db.SaveChangesAsync())
            {
                var node = typeof(TEntity).Name.ToLower();
                return Results.Created($"/{node}s/{entity.Id}", entity);
            }
            
        }
        catch { }
        return Results.BadRequest($"Couldn't add the {typeof(TEntity)}");
    }
}