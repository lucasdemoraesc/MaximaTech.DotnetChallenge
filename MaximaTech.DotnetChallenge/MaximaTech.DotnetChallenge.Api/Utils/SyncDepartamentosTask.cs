using MaximaTech.DotnetChallenge.Api.Data;
using MaximaTech.DotnetChallenge.Api.Data.Repositories.Implementations;
using MaximaTech.DotnetChallenge.Api.Services.Implementations;
using MaximaTech.DotnetChallenge.Api.Services.Interfaces;

namespace MaximaTech.DotnetChallenge.Api.Utils
{
    public class SyncDepartamentosTask
    {
        private IDepartamentoService _departamentoService;

        public SyncDepartamentosTask()
        {
            var dbContext = new ApplicationContextFactory().CreateDbContext(new string[0]);
            var _departamentoRepository = new DepartamentoRepository(dbContext);
            _departamentoService = new DepartamentoService(_departamentoRepository, ConnectionStringUtil.GetConnectionString("ApiDepartamentosBaseUrl"));
        }

        public void Run()
        {
            _departamentoService.SyncDataWithDepartamentosApi();
        }
    }
}
