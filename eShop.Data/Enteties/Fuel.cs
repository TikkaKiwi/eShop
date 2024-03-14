namespace eShop.Data.Enteties;

//public enum FuelType { Petrol, Diesel, Electric, Hybrid}

public class Fuel : IEntity
{
    public int Id { get; set; }
    public string FuelName { get; set; } = string.Empty;
    public List<Car> Cars { get; set; } = [];

    //public FuelType Type { get; set; }
}
