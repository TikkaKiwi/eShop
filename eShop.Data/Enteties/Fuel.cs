namespace eShop.Data.Enteties;

public enum FuelType { Petrol, Diesel, Electric, Hybrid}

public class Fuel : IEntity
{
    public int Id { get; set; }
    public FuelType Type { get; set; }
    public OptionType? OptionType { get; set; }
    public List<Car> Cars { get; set; } = [];
}
