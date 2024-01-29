using Microsoft.EntityFrameworkCore;

namespace eShop.Data.Enteties;

public class Filter : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string TypeName { get; set; }

    public OptionType OptionType { get; set; }

    public FilterOption? FilterOption { get; set; }
    public List<Category>? Categories { get; } = [];
    public List<Option>? Options { get; } = [];
}
