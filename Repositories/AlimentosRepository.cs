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
}