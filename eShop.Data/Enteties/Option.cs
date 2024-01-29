namespace eShop.Data.Enteties;

public class Option : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public OptionType OptionType { get; set; }

    public bool IsSelected { get; set; }

    public int FilterId { get; set; }
    public Filter? Filter { get; set; }
}
