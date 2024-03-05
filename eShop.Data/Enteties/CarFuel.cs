namespace eShop.Data.Enteties;

public class CarFuel
{
    public int CarId { get; set; }
    public int FuelId { get; set; }
    public Car? Car { get; set; }
    public Fuel? Fuel { get; set; }

}