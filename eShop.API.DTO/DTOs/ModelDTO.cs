﻿using eShop.Data.Shared.Enums;

namespace eShop.API.DTO.DTOs;

public class ModelPostDTO
{
    public string ModelName { get; set; } = string.Empty;
    public OptionType? OptionType { get; set; }
    public bool IsSelected { get; set; }
}

public class ModelPutDTO : ModelPostDTO
{
    public int Id { get; set; }
}

public class ModelGetDTO : ModelPutDTO
{

}