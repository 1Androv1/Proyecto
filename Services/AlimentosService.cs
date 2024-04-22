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
    
    public async Task CompraAlimentos(AlimentosCompraDto alimentosCompraDto, int idUser, int alimentosId)
    {
        int idAlimentos = alimentosCompraDto.IdAlimentos;
        var alimentosExist = await alimentosRepository.GetDetailAlimentos(idAlimentos);
        
        if(alimentosCompraDto.CantidadDisponible > alimentosExist!.CantidadDisponible)
            throw new ValidationException($"No puedes comprar mas de la cantidad que cuenta el producto, Cantidad: {alimentosExist.CantidadDisponible}");

        if (alimentosExist == null)
            throw new ValidationException($"Los Alimento {idAlimentos} no existen");

        Alimentos alimentosModel = new Alimentos
        {
            Nombre = alimentosCompraDto.Nombre,
            Descripción = alimentosCompraDto.Descripción,
            Precio = alimentosCompraDto.Precio,
            CantidadDisponible = alimentosCompraDto.CantidadDisponible
        };        
        
        await alimentosRepository.CompraAlimentos(alimentosModel, alimentosCompraDto.CantidadDisponible, idUser, alimentosId);
    }
}