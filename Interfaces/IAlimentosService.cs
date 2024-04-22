using Dtos;

namespace Interfaces;

public interface IAlimentosService
{
    Task<List<AlimentosListDto>> GetAllAlimentos();
}