using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MaximaTech.DotnetChallenge.Domain.Models;

namespace MaximaTech.DotnetChallenge.Api.Data.Repositories.Interfaces
{
    public interface IBaseRepository<TModel> where TModel : BaseModel
    {
        Guid GetIdFromCodigo(int codigo);

        Task<TModel> FindByCodigoAsync(int codigo);

        Task<IEnumerable<TModel>> ListAsync();

        Task AddAsync(TModel model);

        void AddRange(IEnumerable<TModel> models);

        Task Update(TModel model);

        Task Remove(TModel model);

        bool Exists(int codigo);
    }
}
