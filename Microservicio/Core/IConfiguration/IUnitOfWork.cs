using System.Threading.Tasks;
using Microservicio.Core.IRepositories;

namespace Microservicio.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IPersonaRepository Personas { get; }

        IClienteRepository Clientes { get; }

        Task CompleteAsync();
    }
}
