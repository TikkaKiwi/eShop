namespace eShop.Data.Enteties;

public class ColourCar
{
    public int ColourId { get; set; }
    public int CarId { get; set; }
    public Colour? Colour { get; set; }
    public Car? Car { get; set; }
}
