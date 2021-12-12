using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MaximaTech.DotnetChallenge.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MaximaTech.DotnetChallenge.Web.Controllers
{
    [Route("[controller]")]
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
            var result = await DeserializeResponseObject<IEnumerable<Produto>>(response);

            return View("Index", result);
        }

        [Route("{codigo}")]
        public async Task<IActionResult> Edit(int codigo)
        {
            if (codigo != 0)
            {
                var response = await _httpClient.GetAsync($"Produtos/{codigo}");
                var result = await DeserializeResponseObject<Produto>(response);
                return View("Edit", result);
            }
            return View("Edit");
        }

        [Route("New")]
        public IActionResult New()
        {
            return View("Edit");
        }

        [Route("Inativar/{codigo}")]
        public async Task<IActionResult> Remove(int codigo)
        {
            await _httpClient.DeleteAsync($"Produtos/{codigo}");
            return await Index();
        }
    }
}
