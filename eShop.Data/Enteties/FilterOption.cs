namespace eShop.Data.Enteties;

public class FilterOption : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Filter> Filters { get; set; } = [];
}
