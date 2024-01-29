namespace eShop.Data.Enteties;

public class Colour : IEntity
{
    public int Id { get; set; }
    public string ColourName { get; set; }
    public OptionType? OptionType { get; set; }
    public List<Car>? Cars { get; set; }
}
