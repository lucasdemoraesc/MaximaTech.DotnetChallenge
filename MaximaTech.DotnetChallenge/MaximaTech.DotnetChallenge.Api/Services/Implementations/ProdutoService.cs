using MaximaTech.DotnetChallenge.Api.Data.Repositories.Interfaces;
using MaximaTech.DotnetChallenge.Api.Services.Interfaces;
using MaximaTech.DotnetChallenge.Domain.Models;

namespace MaximaTech.DotnetChallenge.Api.Services.Implementations
{
    public class ProdutoService : BaseService<Produto>, IProdutoService
    {
        public ProdutoService(IProdutoRepository repository) : base(repository)
        {
        }
    }
}
