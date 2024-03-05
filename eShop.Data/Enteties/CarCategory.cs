namespace eShop.Data.Enteties;

public class CarCategory
{
    public int CarId { get; set; }
    public int CategoryId { get; set; }
    public Car? Car { get; set; }
    public Category? Category { get; set; }

}
