using AutoMapper;
using Dtos;
using Models;

namespace Helpers.Objects;

public static class HelperAutoMapper
{
    public static TDto ConvertModelToDto<TModel, TDto>(this TModel model)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TModel, TDto>();
        });
        return config.CreateMapper().Map<TModel, TDto>(model);
    }

    public static TModel ConvertDtoToModel<TDto, TModel>(this TDto dto)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TDto, TModel>();
        });
        return config.CreateMapper().Map<TDto, TModel>(dto);
    }
    
    public static TModel ConvertUserDtoToModel<TDto, TModel>(this TDto dto)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<UserDto, Users>();
        });
        return config.CreateMapper().Map<TDto, TModel>(dto);
    }
    
    public static TDto ConvertUserToDto<TModel, TDto>(this TModel model)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TModel, TDto>();
        });
        return config.CreateMapper().Map<TModel, TDto>(model);
    }
    public static TModel ConvertTaksDtoToModel<TDto, TModel>(this TDto dto)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TaksDto, Tasks>();
        });
        return config.CreateMapper().Map<TDto, TModel>(dto);
    }
    public static TDto ConvertModelTaskIdToDto<TModel, TDto>(this TModel model)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Tasks, TaksDto>();
        });
        return config.CreateMapper().Map<TModel, TDto>(model);
    }
}