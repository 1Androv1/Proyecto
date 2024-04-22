using AutoMapper;
using Dtos;
using Dtos.Returns;
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
            cfg.CreateMap<RolDto, Rols>();
        });
        return config.CreateMapper().Map<TDto, TModel>(dto);
    }
    
    public static TModel ConvertAlimentosDtoToModel<TDto, TModel>(this TDto dto)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<AlimentosDto, Alimentos>();
        });
        return config.CreateMapper().Map<TDto, TModel>(dto);
    }
    
    public static TDto ConvertUserToDto<TModel, TDto>(this TModel model)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Users, UserReturnDto>();
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
    public static TDto ConvertModelAlimentosIdToDto<TModel, TDto>(this TModel model)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Alimentos, AlimentosDto>();
        });
        return config.CreateMapper().Map<TModel, TDto>(model);
    }
    public static List<TDto> ConvertTaskListToDto<TModel, TDto>(this List<TModel> models)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Tasks, TaskListDto>();
            cfg.CreateMap<TaksStatus, TaksStatusListDto>();
            cfg.CreateMap<Users, UsersListDto>();
        });
        return config.CreateMapper().Map<List<TModel>, List<TDto>>(models);
    }
    
    public static List<TDto> ConvertAlimentosListToDto<TModel, TDto>(this List<TModel> models)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Alimentos, AlimentosListDto>();
        });
        return config.CreateMapper().Map<List<TModel>, List<TDto>>(models);
    }
}