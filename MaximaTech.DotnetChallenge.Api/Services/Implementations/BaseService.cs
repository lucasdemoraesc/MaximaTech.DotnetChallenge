using System.Collections.Generic;
using System.Threading.Tasks;
using MaximaTech.DotnetChallenge.Api.Data.Repositories.Interfaces;
using MaximaTech.DotnetChallenge.Api.Services.Interfaces;
using MaximaTech.DotnetChallenge.Domain.Models;

namespace MaximaTech.DotnetChallenge.Api.Services.Implementations
{
    public abstract class BaseService<TModel> : IBaseService<TModel>
        where TModel : BaseModel
    {
        protected readonly IBaseRepository<TModel> _repository;

        public BaseService(IBaseRepository<TModel> repository)
        {
            _repository = repository;
        }

        public virtual async Task<TModel> FindByCodigoAsync(int codigo)
        {
            return await _repository.FindByCodigoAsync(codigo);
        }

        public virtual async Task<IEnumerable<TModel>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public virtual async Task AddAsync(TModel model)
        {
            if (!Exists(model.Codigo))
                await _repository.AddAsync(model);
        }

        public virtual void AddRange(IEnumerable<TModel> models)
        {
            IList<TModel> modelsToAdd = new List<TModel>();

            foreach (TModel model in models)
            {
                if (!Exists(model.Codigo))
                    modelsToAdd.Add(model);
            }

            _repository.AddRange(modelsToAdd);
        }

        public virtual async Task Update(TModel model)
        {
            model.Id = _repository.GetIdFromCodigo(model.Codigo);
            await _repository.Update(model);
        }

        public virtual async Task Remove(int codigo)
        {
            var model = await _repository.FindByCodigoAsync(codigo);
            await _repository.Remove(model);
        }

        public virtual bool Exists(int codigo)
        {
            return _repository.Exists(codigo);
        }
    }
}
