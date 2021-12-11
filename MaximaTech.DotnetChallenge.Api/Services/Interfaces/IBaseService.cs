using System.Collections.Generic;
using System.Threading.Tasks;
using MaximaTech.DotnetChallenge.Domain.Models;

namespace MaximaTech.DotnetChallenge.Api.Services.Interfaces
{
    public interface IBaseService<TModel> where TModel : BaseModel
    {
        Task<TModel> FindByCodigoAsync(int codigo);

        Task<IEnumerable<TModel>> ListAsync();

        Task AddAsync(TModel model);

        Task AddRangeAsync(IEnumerable<TModel> models);

        Task Update(TModel model);

        Task Remove(int codigo);

        bool Exists(int codigo);
    }
}
