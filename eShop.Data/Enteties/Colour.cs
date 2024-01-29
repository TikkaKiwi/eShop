namespace eShop.Data.Enteties;

public class Colour : IEntity
{
    public int Id { get; set; }
    public string ColourName { get; set; }
    public string ColorHex { get; set; } = "#000";
    public string BkColorHex { get; set; } = "#FFF";
    public OptionType? OptionType { get; set; }
    public List<Car> Cars { get; set; } = [];
}
