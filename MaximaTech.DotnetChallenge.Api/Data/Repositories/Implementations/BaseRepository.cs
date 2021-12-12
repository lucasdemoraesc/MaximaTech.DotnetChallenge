using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaximaTech.DotnetChallenge.Api.Data.Repositories.Interfaces;
using MaximaTech.DotnetChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MaximaTech.DotnetChallenge.Api.Data.Repositories.Implementations
{
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel>
        where TModel : BaseModel
    {
        protected readonly ApplicationContext Context;
        protected readonly DbSet<TModel> Persistence;

        /// <summary>
		/// Inicia uma nova instância de <see cref="BaseRepository{TModel}"/> configurando
        /// o DbSet a ser utilizado.
		/// </summary>
		/// <param name="contexto">O contexto da aplicação (via injeção de dependência).</param>
		public BaseRepository(ApplicationContext context)
        {
            Context = context;
            Persistence = Context.Set<TModel>();
        }


        public virtual async Task<TModel> FindByCodigoAsync(int codigo)
        {
            return await Persistence.Where(x => x.Codigo == codigo).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<TModel>> ListAsync()
        {
            return await Persistence.ToListAsync();
        }

        public virtual async Task AddAsync(TModel model)
        {
            Persistence.Add(model);
            await Context.SaveChangesAsync();
        }

        public virtual void AddRange(IEnumerable<TModel> models)
        {
            Persistence.AddRange(models);
            Context.SaveChangesAsync();
        }

        public virtual async Task Update(TModel model)
        {
            Persistence.Update(model);
            await Context.SaveChangesAsync();
        }

        public virtual async Task Remove(TModel model)
        {
            model.Status = false;
            await Update(model);
        }

        public virtual bool Exists(int codigo)
        {
            return Persistence.Any(model => model.Codigo == codigo);
        }

        public virtual Guid GetIdFromCodigo(int codigo)
        {
            return Persistence.Where(x => x.Codigo == codigo).Select(x => x.Id).FirstOrDefault();
        }
    }
}
