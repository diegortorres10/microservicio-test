using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microservicio.Core.IRepositories;
using Microservicio.Data;
using Microservicio.Model;

namespace Microservicio.Core.Repository
{
    public class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {
        public PersonaRepository(
            ApplicationDbContext context,
            ILogger logger
        ) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Persona>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Persona} Get all method error", typeof(PersonaRepository));
                return new List<Persona>();
            }
        }
    }
}
