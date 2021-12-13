using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MaximaTech.DotnetChallenge.Domain.Models;
using MaximaTech.DotnetChallenge.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MaximaTech.DotnetChallenge.Web.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class ProdutoController : BaseController
    {
        private readonly HttpClient _httpClient;

        public ProdutoController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration.GetConnectionString("MaximaApiBaseUrl"));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("Produtos");
            var result = await DeserializeResponseObject<IEnumerable<ProdutoViewModel>>(response);

            return View("Index", result);
        }

        [Route("{codigo}")]
        public async Task<IActionResult> Edit(int codigo)
        {
            ProdutoViewModel produto = new ProdutoViewModel();

            if (codigo != 0)
            {
                produto = await GetProduto(codigo);
                return View("Edit", produto);
            }

            produto.Departamentos = await GetDepartamentos();
            return View("Edit", produto);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew(ProdutoViewModel produto)
        {
            var body = GetContent(produto);
            var response = await _httpClient.PostAsync("Produtos", body);
            return await Index();
        }

        [HttpPost]
        [Route("{codigo}")]

        public async Task<IActionResult> Update(int codigo, ProdutoViewModel produto)
        {
            var body = GetContent(produto);
            var response = await _httpClient.PutAsync($"Produtos/{codigo}", body);
            return await Index();
        }

        [Route("New")]
        public Task<IActionResult> New()
        {
            return Edit(0);
        }

        [Route("Inativar/{codigo}")]
        public async Task<IActionResult> Remove(int codigo)
        {
            await _httpClient.DeleteAsync($"Produtos/{codigo}");
            return await Index();
        }

        #region METODOS PRIVADOS

        private async Task<ProdutoViewModel> GetProduto(int codigo)
        {
            var response = await _httpClient.GetAsync($"Produtos/{codigo}");
            ProdutoViewModel produto = await DeserializeResponseObject<ProdutoViewModel>(response);
            produto.Departamentos = await GetDepartamentos();
            return produto;
        }

        private async Task<IEnumerable<Departamento>> GetDepartamentos()
        {
            var response = await _httpClient.GetAsync("Departamentos");
            var result = await DeserializeResponseObject<IEnumerable<Departamento>>(response);
            return result;
        }

        #endregion
    }
}
