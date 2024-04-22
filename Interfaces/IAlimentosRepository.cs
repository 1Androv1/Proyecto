using Models;

namespace Interfaces;

public interface IAlimentosRepository
{
    Task<List<Alimentos>> GetAllAlimentos();
}