namespace eShop.Data.Enteties;

public class Colour : IEntity
{
    public int Id { get; set; }
    public string ColourName { get; set; }
    public OptionType MyCar { get; set; }
    public List<Car> Cars { get; set; }
}
