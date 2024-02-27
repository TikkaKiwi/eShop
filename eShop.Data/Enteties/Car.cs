using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Data.Enteties;

public class Car : IEntity
{
    public int Id { get; set; }
    public string ModelName { get; set; }   
    public int Year { get; set; }
    public string Description { get; set; }
    public string PictureUrl { get; set; }
    public List<Category>? Categories { get; set; } = [];
    public List<Colour>? Colours { get; set; } = [];
    public List<Fuel>? Fuels { get; set; } = [];
    public int BrandId { get; set; }
    public Brand? Brand { get; set; }
}