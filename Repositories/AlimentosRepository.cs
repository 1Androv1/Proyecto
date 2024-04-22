using System.Net;
using Interfaces;
using Contexts;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Net.Mail;

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
    
    public async Task CompraAlimentos(Alimentos? alimentos, int cantidadCompra, int idUser, int alimentosId)
    {
        if (alimentos == null)
            throw new ArgumentNullException(nameof(alimentos), "El Alimento proporcionado es nulo.");

        using var transaction = await sqlDbContext.Database.BeginTransactionAsync();
    
        try
        {
            Pedidos pedido = new Pedidos
            {
                UserId = idUser,
                FechaPedido = DateTime.Now 
            };

            await sqlDbContext.Pedidos!.AddAsync(pedido);
            await sqlDbContext.SaveChangesAsync();
            
            DetallesPedido detallePedido = new DetallesPedido
            {
                PedidoId = pedido.IdPedidos,
                AlimentoId = alimentosId,
                Cantidad = cantidadCompra
            };

            await sqlDbContext.DetallesPedido!.AddAsync(detallePedido);
            await sqlDbContext.SaveChangesAsync();

            var alimentoExistente = await sqlDbContext.Alimentos!
                .FirstOrDefaultAsync(t => t.IdAlimentos == alimentosId);

            if (alimentoExistente == null)
                throw new InvalidOperationException($"No se encontró ningún alimento con IdAlimentos = {alimentos.IdAlimentos}.");

            alimentoExistente.CantidadDisponible -= cantidadCompra;

            await sqlDbContext.SaveChangesAsync();
            
            EnvioCorreo("androv389@gmail.com", alimentoExistente.Nombre, alimentoExistente.Precio, cantidadCompra);
            await transaction.CommitAsync();
            
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw; 
        }
    }

    public void EnvioCorreo(string email, string? nombreAlimento, decimal precio, int cantidadCompra)
    {
        try
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                //Destinatario
                mailMessage.To.Add(email);

                mailMessage.Subject = "Compra Realizada";
                mailMessage.Body = $"Realizaste una compra de {cantidadCompra} {nombreAlimento}, con precio de ${precio*cantidadCompra}";
                mailMessage.IsBodyHtml = false;

                mailMessage.From = new MailAddress("rojaspruebasalejandro@gmail.com", "ALERTA");

                using (SmtpClient cliente = new SmtpClient())
                {
                    cliente.UseDefaultCredentials = false;
                    cliente.Credentials = new NetworkCredential("rojaspruebasalejandro@gmail.com", "fqrh phga jgli cmrv");
                    cliente.Port = 587;
                    cliente.EnableSsl = true;

                    cliente.Host = "smtp.gmail.com";
                    cliente.Send(mailMessage);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}