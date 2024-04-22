using Interfaces;
using Contexts;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories;

public class AlimentosRepository(SqlDbContext sqlDbContext): IAlimentosRepository
{
    public async Task<List<Alimentos>> GetAllAlimentos()
    {
        return await sqlDbContext.Alimentos!
            .ToListAsync();
    }
    public async Task SaveNewAlimentos(Alimentos alimentos)
    {
        sqlDbContext.Alimentos!.Add(alimentos);
        await sqlDbContext.SaveChangesAsync();
    }
    public async Task<Alimentos?> GetDetailAlimentos(int id)
    {
        return await sqlDbContext.Alimentos!
            .FirstOrDefaultAsync(a => a.IdAlimentos == id);
    }
    public async Task UpdateAlimentos(Alimentos? alimentos)
    {
        if (alimentos == null)
            throw new ArgumentNullException(nameof(alimentos), "El Alimento proporcionadp es nulo.");

        var taskExist = await sqlDbContext.Alimentos!
            .FirstOrDefaultAsync(t => t.IdAlimentos == alimentos.IdAlimentos);

        if (taskExist == null)
            throw new InvalidOperationException($"No se encontró ninguna tarea con IdTask = {alimentos.IdAlimentos}.");
        
        taskExist.Nombre = alimentos.Nombre;
        taskExist.Descripción = alimentos.Descripción;
        taskExist.Precio = alimentos.Precio;
        taskExist.CantidadDisponible = alimentos.CantidadDisponible;
        
        await sqlDbContext.SaveChangesAsync();
    }
    public async Task DeletedAlimentosId(int idAlimentos)
    {
        var alimentosDelete = await sqlDbContext.Alimentos!
            .FirstOrDefaultAsync(t => t.IdAlimentos == idAlimentos);
        
        if (alimentosDelete != null)
        {
            sqlDbContext.Alimentos!.Remove(alimentosDelete);
        
            await sqlDbContext.SaveChangesAsync();
        }
    }
}