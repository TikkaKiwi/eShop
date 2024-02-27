namespace eShop.API.DTO.DTOs;

public class CarFuelPostDTO
{
    public int FuelId { get; set; }
    public int CarId { get; set; }
}
public class CarFuelDeleteDTO : CarFuelPostDTO
{
}
public class CarFuelGetDTO : CarFuelPostDTO
{
}

public class CarFuelSmallGetDTO
{
    public int FuelId { get; set; }
}