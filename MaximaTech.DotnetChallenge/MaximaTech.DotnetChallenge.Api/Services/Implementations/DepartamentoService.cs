using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.Json;
using MaximaTech.DotnetChallenge.Api.Data.Repositories.Interfaces;
using MaximaTech.DotnetChallenge.Api.Services.Interfaces;
using MaximaTech.DotnetChallenge.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace MaximaTech.DotnetChallenge.Api.Services.Implementations
{
    public class DepartamentoService : BaseService<Departamento>, IDepartamentoService
    {
        private readonly string _apiDepartamentosBaseUrl;

        public DepartamentoService(IDepartamentoRepository repository, IConfiguration configuration) : base(repository)
        {
            _apiDepartamentosBaseUrl = configuration.GetConnectionString("ApiDepartamentosBaseUrl");
        }

        public DepartamentoService(IDepartamentoRepository repository, string apiDepartamentosBaseUrl) : base(repository)
        {
            _apiDepartamentosBaseUrl = apiDepartamentosBaseUrl;
        }

        public void SyncDataWithDepartamentosApi()
        {
            Debug.WriteLine(DateTime.Now + " :: Buscando dados da API de departamentos");

            IEnumerable<Departamento> departamentos = FetchDataFromApi();
            base.AddRange(departamentos);
        }

        private IEnumerable<Departamento> FetchDataFromApi()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_apiDepartamentosBaseUrl);
            request.Method = "GET";
            request.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string json;

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                json = reader.ReadToEnd();
            }

            IEnumerable<Departamento> departamentos = JsonSerializer.Deserialize<List<Departamento>>(
                json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return departamentos;
        }
    }
}
