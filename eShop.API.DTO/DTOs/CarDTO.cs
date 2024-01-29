using eShop.Data.Enteties;

namespace eShop.API.DTO.DTOs;

public class CarPostDTO
{
    public string Name { get; set; }
}
public class CarPutDTO : CarPostDTO
{
    public int Id { get; set; }
}
public class CarGetDTO : CarPutDTO
{
    //public List<FilterGetDTO> Filter { get; set; }
}
