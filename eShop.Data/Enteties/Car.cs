namespace eShop.Data.Enteties;

public class Car : IEntity
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string Owner { get; set; }
    public List<Category>? Categories { get; set; }
    public List<Colour> Colours { get; set; }
    public List<Brand> Brands { get; set; }
    public List<Fuel> Fuels { get; set; }
    public List<Model> Models { get; set; }     
}