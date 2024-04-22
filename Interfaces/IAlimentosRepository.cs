using Models;

namespace Interfaces;

public interface IAlimentosRepository
{
    Task<List<Alimentos>> GetAllAlimentos();
    Task SaveNewAlimentos(Alimentos alimentos);
    Task<Alimentos?> GetDetailAlimentos(int id);
    Task UpdateAlimentos(Alimentos? alimentos);
    Task DeletedAlimentosId(int idAlimentos);
    Task CompraAlimentos(Alimentos? alimentos, int cantidadCompra, int idUser, int alimentosId);
}