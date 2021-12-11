using System;
using System.Collections.Generic;
using System.Linq;
using MaximaTech.DotnetChallenge.Domain.Models;

namespace MaximaTech.DotnetChallenge.Api.Data
{
    /// <summary>
    /// Classe responsável por preencher o banco de dados.
    /// </summary>
    public class DatabaseFiller
    {
        private ApplicationContext _context;
        private IList<Departamento> _departamentos;

        /// <summary>
        /// Inicia uma nova instância da classe.
        /// </summary>
        /// <param name="context">O contexto de banco de dados a ser utilizado.</param>
        public DatabaseFiller(ApplicationContext context)
        {
            _context = context;
            _departamentos = new List<Departamento>();
        }

        /// <summary>
        /// Preenche os DbSets definidos com valores gerados automaticamente.
        /// </summary>
        public void Fill()
        {
            FillDepartamentos();
            FillProdutos();

            _context.SaveChanges();
        }

        private void FillDepartamentos()
        {
            if (_context.Departamentos.Any())
                return;

            Departamento departamento;

            for (int i = 1; i <= 5; i++)
            {
                departamento = new Departamento
                {
                    Id = new Guid(),
                    Codigo = 899 + i,
                    Descricao = "Departamento " + i,
                    Status = true
                };

                _departamentos.Add(departamento);
            }

            _context.Departamentos.AddRange(_departamentos);
        }

        private void FillProdutos()
        {
            if (_context.Produtos.Any())
                return;

            var rand = new Random();
            Produto produto;

            for (int i = 1; i <= 1000; i++)
            {
                produto = new Produto
                {
                    Id = new Guid(),
                    Codigo = 999 + i,
                    Descricao = "Produto " + i,
                    Departamento = _departamentos[rand.Next(1, 5)],
                    Preco = rand.Next(10, 2000),
                    Status = i % 2 == 0 ? true : false
                };

                _context.Produtos.Add(produto);
            }
        }
    }
}
