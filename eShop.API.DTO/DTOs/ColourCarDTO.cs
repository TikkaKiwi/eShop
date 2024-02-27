namespace eShop.API.DTO.DTOs;

public class ColourCarPostDTO
{
    public int ColorId { get; set; }
    public int ProductId { get; set; }
}
public class ColourCarDeleteDTO : ColourCarPostDTO
{
}
public class ColourCarGetDTO : ColourCarPostDTO
{
}

public class ColourCarSmallGetDTO
{
    public int ColorId { get; set; }
}