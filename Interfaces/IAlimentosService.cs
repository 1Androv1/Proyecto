using Dtos;

namespace Interfaces;

public interface IAlimentosService
{
    Task<List<AlimentosListDto>> GetAllAlimentos();
    Task SaveAnNewAlimentos(AlimentosDto alimentosDto);
    Task UpdateAlimentos(AlimentosUpdateDto alimentosUpdateDto);
    Task<AlimentosDto?> GetDetailAlimentos(int idAlimentos);
    Task DeletedAlimentosId(int idAlimentos);
}