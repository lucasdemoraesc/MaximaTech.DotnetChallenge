using System.Collections.Generic;
using MaximaTech.DotnetChallenge.Domain.Models;

namespace MaximaTech.DotnetChallenge.Web.Models
{
    /// <summary>
    /// Modelo de produto para ser utilizado nas Views.
    /// </summary>
    public class ProdutoViewModel : Produto
    {
        public IEnumerable<Departamento> Departamentos { get; set; }
    }
}
