using eShop.Data.Shared.Enums;

namespace eShop.API.DTO.DTOs;

public class FuelPostDTO
{
    public string FuelName { get; set; }
}

public class FuelPutDTO : FuelPostDTO
{
    public int Id { get; set; }
}

public class FuelGetDTO : FuelPutDTO
{
    public bool IsSelected { get; set; }
}