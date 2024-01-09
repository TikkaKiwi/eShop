using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Data.Enteties;

public class Car : IEntity
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string Owner { get; set; }
    public List<Category>? Categories { get; set; }
    public List<Colour> Colours { get; set; }
    [ForeignKey ("Brand")]
    public Brand Brand { get; set; }
    public List<Fuel> Fuels { get; set; }
    public List<Model> Models { get; set; }     
}