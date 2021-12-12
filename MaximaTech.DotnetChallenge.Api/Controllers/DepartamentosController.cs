using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaximaTech.DotnetChallenge.Api.Services.Interfaces;
using MaximaTech.DotnetChallenge.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaximaTech.DotnetChallenge.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;

        public DepartamentosController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetAllAsync()
        {
            var departamentos = await _departamentoService.ListAsync();

            return departamentos == null || departamentos.Count() <= 0
                ? NoContent() : Ok(departamentos);
        }
    }
}
