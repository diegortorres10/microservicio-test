using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microservicio.Model;
using Microservicio.Core.IRepositories;
using Microservicio.Data;

namespace Microservicio.Core.Repository
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(
            ApplicationDbContext context,
            ILogger logger
        ) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<Cliente>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Cliente} Get all method error", typeof(ClienteRepository));
                return new List<Cliente>();
            }
        }

        public override async Task<bool> Upsert(Cliente entity)
        {
            try
            {
                var existingClient = await dbSet.Where(x => x.Persona.Identificacion == entity.Persona.Identificacion)
                                                        .FirstOrDefaultAsync();

                if (existingClient == null)
                    return await Add(entity);

                existingClient.ClienteId = entity.ClienteId;
                existingClient.Estado = entity.Estado;
                existingClient.Contraseña = entity.Contraseña;
                existingClient.Cuentas = entity.Cuentas;
                existingClient.Persona = entity.Persona;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Cliente} Upsert method error", typeof(ClienteRepository));
                return false;
            }
        }
    }
}
