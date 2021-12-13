using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaximaTech.DotnetChallenge.Domain.Models;

namespace MaximaTech.DotnetChallenge.Tests
{
    internal static class ObjectsFactory
    {
        public static Produto GetProduto()
        {
            return new Produto
            {
                Id = new Guid(),
                Codigo = 1,
                Descricao = "Produto topissimo",
                Departamento = GetDepartamento(),
                Preco = 5000,
                Status = true
            };
        }

        public static Departamento GetDepartamento()
        {
            return new Departamento
            {
                Id = new Guid(),
                Codigo = 1,
                Descricao = "Departamento topissimo",
                Status = true
            };
        }
    }
}
