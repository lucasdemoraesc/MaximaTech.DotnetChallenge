using System;
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
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IDepartamentoService _departamentoService;

        public ProdutosController(IProdutoService produtoService, IDepartamentoService departamentoService)
        {
            _produtoService = produtoService;
            _departamentoService = departamentoService;
        }

        [HttpGet("{codigo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Produto>> GetByCodigo(int codigo)
        {
            var produto = await _produtoService.FindByCodigoAsync(codigo);

            return produto == null ? NotFound() : Ok(produto);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<Produto>>> GetAllAsync()
        {
            var produtos = await _produtoService.ListAsync();

            return produtos == null || produtos.Count() <= 0
                ? NoContent() : Ok(produtos);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Produto>> AddNew(Produto produto)
        {
            ProductNotExists(produto.Codigo);
            produto.Departamento = await FillDepartamento(produto.Departamento);

            if (!ModelState.IsValid)
            {
                return ProblemasDeValidacao();
            }

            await _produtoService.AddAsync(produto);
            return CreatedAtAction("GetByCodigo", new { codigo = produto.Codigo }, produto);
        }

        [HttpPut("{codigo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Produto>> Update(int codigo, Produto produto)
        {
            if (codigo != produto.Codigo)
                return BadRequest();

            ProductExists(codigo);
            produto.Departamento = await FillDepartamento(produto.Departamento);

            if (!ModelState.IsValid)
                return ProblemasDeValidacao();

            await _produtoService.Update(produto);
            return Ok(produto);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Produto>> Remove(int codigo)
        {
            ProductExists(codigo);

            if (!ModelState.IsValid)
                return ProblemasDeValidacao();

            await _produtoService.Remove(codigo);
            return Ok();
        }

        #region METODOS PRIVADOS

        private void ProductNotExists(int codigo)
        {
            if (_produtoService.Exists(codigo))
            {
                ModelState.AddModelError("Codigo", "Já existe um produto com o código informado");
            }
        }

        private void ProductExists(int codigo)
        {
            if (!_produtoService.Exists(codigo))
            {
                ModelState.AddModelError("Codigo", "Nenhum produto encontrado com o código informado");
            }
        }

        private async Task<Departamento> FillDepartamento(Departamento departamento)
        {
            if (departamento.Id == Guid.Empty)
            {
                var departamentoPersistido = await _departamentoService.FindByCodigoAsync(departamento.Codigo);

                if (departamentoPersistido == null)
                {
                    ModelState.AddModelError("Departamento", "O Departamento informado não existe");
                    return null;
                }

                return departamentoPersistido;
            }

            return departamento;
        }

        private ActionResult<Produto> ProblemasDeValidacao()
        {
            return ValidationProblem(
                "Foram encontradas algumas inconsistências de validação",
                null,
                StatusCodes.Status400BadRequest,
                "Inconsistências de validação",
                null,
                ModelState);
        }

        #endregion
    }
}
