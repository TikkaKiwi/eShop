using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;

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
        app.MapPut($"/api/{node}s/" + "{id}", HttpPutAsync<TEntity, TPutDto>);
        app.MapDelete($"/api/{node}s/" + "{id}", HttpDeleteAsync<TEntity>);
    }

    public static void AddEndPoint<TEntity, TPostDto, TDeleteDto>(this WebApplication app)
        where TEntity : class where TPostDto : class where TDeleteDto : class
    {
        var node = typeof(TEntity).Name.ToLower();
        app.MapPost($"/api/{node}s", HttpPostReferenceAsync<TEntity, TPostDto>);
        app.MapDelete($"/api/{node}s", async (IDbService db, [FromBody] TDeleteDto dto) =>
        {
            try
            {
                if (!db.Delete<TEntity, TDeleteDto>(dto)) 
                    return Results.NotFound();
                if (await db.SaveChangesAsync()) 
                    return Results.NoContent();
            }
            catch
            {
            }
            return Results.BadRequest($"Couldn't delete the {typeof(TEntity).Name} entity.");
        });

    }
    public static async Task<IResult> HttpPostReferenceAsync<TEntity, TPostDto>(this IDbService db, TPostDto dto)
        where TEntity : class where TPostDto : class
    {
        try
        {
            var entity = await db.AddAsync<TEntity, TPostDto>(dto);
            if (await db.SaveChangesAsync())
            {
                var node = typeof(TEntity).Name.ToLower();
                return Results.Created($"/{node}s/", entity);
            }
        }
        catch
        {
            var message = Results.NotFound();
            //return Results.NotFound();
        }

        return Results.BadRequest($"Couldn't add the {typeof(TEntity).Name} entity.");
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
            var entity = await db.AddAsync<TEntity, TPostDto>(dto);
            if(await db.SaveChangesAsync())
            {
                var node = typeof(TEntity).Name.ToLower();
                return Results.Created($"/{node}s/{entity.Id}", entity);
            }
            
        }
        catch { }
        return Results.BadRequest($"Couldn't add the {typeof(TEntity)}");
    }

    public static async Task<IResult> HttpPutAsync<TEntity, TPutDto>(this IDbService db, TPutDto dto)
        where TEntity : class, IEntity where TPutDto : class
    {
        try
        {
            db.Update<TEntity, TPutDto>(dto);
            if (await db.SaveChangesAsync()) return Results.NoContent();
        }
        catch
        {
        }

        return Results.BadRequest($"Couldn't update the {typeof(TEntity).Name}");
    }

    public static async Task<IResult> HttpDeleteAsync<TEntity>(this IDbService db, int id)
        where TEntity : class, IEntity
    {
        try
        {
            if (!await db.DeleteAsync<TEntity>(id))
                return Results.NotFound();

            if (await db.SaveChangesAsync())
                return Results.NoContent();
        }
        catch
        {
        }

        return Results.BadRequest($"Couldn't delete the {typeof(TEntity).Name}");
    }
}