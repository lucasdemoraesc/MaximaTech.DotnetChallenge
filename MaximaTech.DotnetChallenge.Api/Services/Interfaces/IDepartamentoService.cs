using System.Threading.Tasks;
using MaximaTech.DotnetChallenge.Domain.Models;

namespace MaximaTech.DotnetChallenge.Api.Services.Interfaces
{
    public interface IDepartamentoService : IBaseService<Departamento>
    {
        Task RunScheduledApiConnection();
    }
}
