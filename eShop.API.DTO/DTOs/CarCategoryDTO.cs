namespace eShop.API.DTO.DTOs;

public class CarCategoryPostDTO
{
    public int CarId { get; set; }
    public int CategoryId { get; set; }
}
public class CarCategoryDeleteDTO : CarCategoryPostDTO
{
}
public class CarCategoryGetDTO : CarCategoryPostDTO
{
}

public class CarCategorySmallGetDTO
{
    public int CategoryId { get; set; }
}