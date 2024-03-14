namespace eShop.Data.Enteties;

public class Brand : IEntity
{
    public int Id { get; set; }
    public string BrandName { get; set; }
    public List<Car> Cars { get; set; } = [];
}
