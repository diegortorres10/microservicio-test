using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microservicio.Core.IConfiguration;
using Microservicio.Core.IRepositories;
using Microservicio.Core.Repository;

namespace Microservicio.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public IPersonaRepository Personas { get; private set; }
        public IClienteRepository Clientes { get; private set; }

        public UnitOfWork(
            ApplicationDbContext context,
            ILoggerFactory loggerFactory
        )
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Personas = new PersonaRepository(_context, _logger);
            Clientes = new ClienteRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
