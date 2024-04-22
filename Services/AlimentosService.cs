using System.ComponentModel.DataAnnotations;
using Dtos;
using Interfaces;
using Models;
using Helpers.Objects;

namespace Services;

public class AlimentosService(IAlimentosRepository alimentosRepository): IAlimentosService
{
    public async Task SaveAnNewAlimentos(AlimentosDto alimentosDto)
    {
        var alimentos = alimentosDto.ConvertAlimentosDtoToModel<AlimentosDto, Alimentos>();
        await alimentosRepository.SaveNewAlimentos(alimentos);
    }
    public async Task<List<AlimentosListDto>> GetAllAlimentos()
    {
        var alimentos = await alimentosRepository.GetAllAlimentos();
        var alimentosDto = alimentos.ConvertAlimentosListToDto<Alimentos, AlimentosListDto>();
        return alimentosDto;
    }
    public async Task UpdateAlimentos(AlimentosUpdateDto alimentosUpdateDto)
    {
        int idAlimentos = alimentosUpdateDto.IdAlimentos;
        var alimentosExist = await alimentosRepository.GetDetailAlimentos(idAlimentos);
        
        if (alimentosExist == null)
            throw new ValidationException($"The Alimento {idAlimentos} does not exist.");

        var alimentosModel = alimentosUpdateDto.ConvertDtoToModel<AlimentosUpdateDto, Alimentos>();
        await alimentosRepository.UpdateAlimentos(alimentosModel);
    }
    public async Task<AlimentosDto?> GetDetailAlimentos(int idAlimentos)
    {
        var alimentosDto = await alimentosRepository.GetDetailAlimentos(idAlimentos);
        return alimentosDto?.ConvertModelAlimentosIdToDto<Alimentos, AlimentosDto>();
    }
    public async Task DeletedAlimentosId(int idTask)
    {
        await alimentosRepository.DeletedAlimentosId(idTask);
    }
}