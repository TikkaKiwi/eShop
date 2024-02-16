using System.Reflection;

namespace eShop.API.DTO.DTOs;

public class CarPostDTO
{
    public string Name { get; set; } = string.Empty;
    public int Year { get; set; } = -1;
    public string Description { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;
}
public class CarPutDTO : CarPostDTO
{
    public int Id { get; set; }
}
public class CarGetDTO : CarPutDTO
{
    public List<ColourGetDTO>? Colours { get; set; }
    //public List<FilterGetDTO> Filter { get; set; }
}
