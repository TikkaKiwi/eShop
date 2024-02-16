using eShop.Data.Shared.Enums;

namespace eShop.API.DTO.DTOs;

public class ColourPostDTO
{
    public string ColourName { get; set; } = string.Empty;
    public string ColorHex { get; set; } = string.Empty;
    public string BkColorHex { get; set; } = string.Empty;
    public OptionType? OptionType { get; set; }
}

public class ColourPutDTO : ColourPostDTO
{
    public int Id { get; set; }
}

public class ColourGetDTO : ColourPutDTO
{
    public bool IsSelected { get; set; }
}