namespace eShop.Data.Context;

public class EShopContext(DbContextOptions<EShopContext> builder) : DbContext(builder)
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Filter> Filters => Set<Filter>();
    public DbSet<Car> Cars => Set<Car>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Colour> Colours => Set<Colour>();
    public DbSet<Fuel> Fuels => Set<Fuel>();

    public DbSet<Model> Models => Set<Model>();
    public DbSet<CarFuel> CarFuels => Set<CarFuel>();
    public DbSet<CarCategory> CarCategories => Set<CarCategory>();
    public DbSet<ColourCar> ColourCar => Set<ColourCar>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Composite Keys
        builder.Entity<ColourCar>()
            .HasKey(pc => new { pc.CarId, pc.ColourId });
        builder.Entity<CarFuel>()
            .HasKey(pc => new { pc.CarId, pc.FuelId });
        builder.Entity<CarCategory>()
            .HasKey(pc => new { pc.CarId, pc.CategoryId });
        builder.Entity<FilterCategory>()
            .HasKey(cf => new { cf.CategoryId, cf.FilterId });
        #endregion

        #region CategoryFilter Many-to-Many Relationship

        builder.Entity<Category>()
            .HasMany(c => c.Filters)
            .WithMany(f => f.Categories)
            .UsingEntity<FilterCategory>();
        #endregion

        #region CarCetegories Many-to-Many Relationship
        builder.Entity<Car>()
            .HasMany(c => c.Categories)
            .WithMany(c => c.Cars)
            .UsingEntity<CarCategory>();
        #endregion

        
        #region CarBrand One-to-Many Relationship
        builder.Entity<Car>()
            .HasOne(b => b.Brand)
            .WithMany(c => c.Cars)
            .HasForeignKey(b => b.BrandId);
        #endregion
        

        #region CarColour Many-to-Many Relationship
        builder.Entity<Car>()
            .HasMany(c => c.Colours)
            .WithMany(c => c.Cars)
            .UsingEntity<ColourCar>();
        #endregion
        
        #region CarFuel Many-to-Many Relationship
        builder.Entity<Car>()
            .HasMany(c => c.Fuels)
            .WithMany(f => f.Cars)
            .UsingEntity<CarFuel>();
        #endregion
        
        #region CarModel One-to-Many Relationship
        builder.Entity<Car>()
            .HasOne(m => m.Model)
            .WithMany(c => c.Cars)
            .HasForeignKey(b => b.ModelId);
        #endregion
        
        #region Filter-Options One-to-Many Relationship
        /*
        builder.Entity<Filter>()
            .HasMany(o => o.Options)
            .WithOne(f => f.Filter);
        */
        #endregion

        #region FilterOptions One-to-One Relationsship
        /*
        builder.Entity<FilterOption>()
            .HasMany(z => z.Filters)
            .WithOne(f => f.FilterOption);
        */
        #endregion
    }
}
