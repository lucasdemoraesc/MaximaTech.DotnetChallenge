using MaximaTech.DotnetChallenge.Api.Data.Repositories.Interfaces;
using MaximaTech.DotnetChallenge.Domain.Models;

namespace MaximaTech.DotnetChallenge.Api.Data.Repositories.Implementations
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
