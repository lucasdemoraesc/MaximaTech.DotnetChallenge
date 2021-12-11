using System.Threading.Tasks;
using MaximaTech.DotnetChallenge.Api.Data.Repositories.Interfaces;
using MaximaTech.DotnetChallenge.Api.Services.Interfaces;
using MaximaTech.DotnetChallenge.Domain.Models;

namespace MaximaTech.DotnetChallenge.Api.Services.Implementations
{
    public class DepartamentoService : BaseService<Departamento>, IDepartamentoService
    {
        public DepartamentoService(IDepartamentoRepository repository) : base(repository)
        {
        }

        public Task RunScheduledApiConnection()
        {
            throw new System.NotImplementedException();
        }
    }
}
