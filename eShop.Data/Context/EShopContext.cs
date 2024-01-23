namespace eShop.Data.Context;

public class EShopContext(DbContextOptions<EShopContext> builder) : DbContext(builder)
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Filter> Filters => Set<Filter>();
    public DbSet<Car> Cars => Set<Car>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Colour> Colours => Set<Colour>();
    public DbSet<Model> Models => Set<Model>();
    public DbSet<Fuel> Fuels => Set<Fuel>();

    public DbSet<CarCategory> CarCategories => Set<CarCategory>();
    public DbSet<ModelCar> ModelCars => Set<ModelCar>();
    public DbSet<ColourCar> ColourCar => Set<ColourCar>();
    public DbSet<FuelCar> FuelCars => Set<FuelCar>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Composite Keys
        builder.Entity<ColourCar>()
            .HasKey(pc => new { pc.CarId, pc.ColourId });
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

        #region ProductCategory Many-to-Many Relationship
        builder.Entity<Car>()
            .HasMany(c => c.Categories)
            .WithMany(c => c.Cars)
            .UsingEntity<CarCategory>();
        #endregion

        #region ProductBrand One-to-Many Relationship
        builder.Entity<Car>()
            .HasOne(b => b.Brand)
            .WithMany(c => c.Cars)
            .HasForeignKey(b => b.BrandId);
        #endregion

        #region ProductColor Many-to-Many Relationship
        builder.Entity<Car>()
            .HasMany(c => c.Colours)
            .WithMany(c => c.Cars)
            .UsingEntity<ColourCar>();
        #endregion

        #region ProductColor Many-to-Many Relationship
        builder.Entity<Car>()
            .HasMany(f => f.Fuels)
            .WithMany(c => c.Cars)
            .UsingEntity<FuelCar>();
        #endregion

        #region ProductColor Many-to-Many Relationship
        builder.Entity<Car>()
            .HasMany(m => m.Models)
            .WithMany(c => c.Cars)
            .UsingEntity<ModelCar>();
        #endregion
    }
}
