using MaximaTech.DotnetChallenge.Api.Data.Repositories.Interfaces;
using MaximaTech.DotnetChallenge.Domain.Models;

namespace MaximaTech.DotnetChallenge.Api.Data.Repositories.Implementations
{
    public class DepartamentoRepository : BaseRepository<Departamento>, IDepartamentoRepository
    {
        public DepartamentoRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
