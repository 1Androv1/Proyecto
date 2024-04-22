using Dtos;
using Interfaces;
using Models;
using Helpers.Objects;

namespace Services;

public class AlimentosService(IAlimentosRepository alimentosRepository): IAlimentosService
{
    public async Task<List<AlimentosListDto>> GetAllAlimentos()
    {
        var alimentos = await alimentosRepository.GetAllAlimentos();
        var alimentosDto = alimentos.ConvertAlimentosListToDto<Alimentos, AlimentosListDto>();
        return alimentosDto;
    }
}