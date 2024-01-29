namespace eShop.Data.Enteties;

public class Fuel : IEntity
{
    public int Id { get; set; }
    public string FuelType { get; set; }
    public OptionType? OptionType { get; set; }
    public List<Car>? Cars { get; set; }
}
