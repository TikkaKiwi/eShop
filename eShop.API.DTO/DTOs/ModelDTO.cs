namespace eShop.API.DTO.DTOs;

public class ModelPostDTO
{
    public string ModelName { get; set; } = string.Empty;
}

public class ModelPutDTO : ModelPostDTO
{
    public int Id { get; set; }
}

public class ModelGetDTO : ModelPutDTO
{

}