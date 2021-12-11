using System;
using MaximaTech.DotnetChallenge.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaximaTech.DotnetChallenge.Tests
{
    [TestClass]
    public class ProdutoTests : BaseTests<Produto>
    {
        private Produto produto;

        public ProdutoTests()
        {
            produto = ObjectsFactory.GetProduto();
        }

        #region TESTA VALIDACOES

        #region CODIGO

        [TestMethod]
        public void Produto_CodigoNaoInformado()
        {
            produto.Codigo = 0;
            Assert.IsTrue(ValidateModel(produto).Count == 1);
        }

        [TestMethod]
        public void Produto_CodigoInformado()
        {
            Assert.IsTrue(ValidateModel(produto).Count == 0);
        }

        #endregion

        #region DESCRICAO

        [TestMethod]
        public void Produto_DescricaoNaoInformada()
        {
            produto.Descricao = string.Empty;
            Assert.IsTrue(ValidateModel(produto).Count == 1);
        }

        [TestMethod]
        public void Produto_DescricaoTamanhoMaximoExcedido()
        {
            produto.Descricao = new string('T', 100);
            Assert.IsTrue(ValidateModel(produto).Count == 1);
        }

        #endregion

        #region DEPARTAMENTO

        [TestMethod]
        public void Produto_DepartamentoNaoInformado()
        {
            produto.Departamento = null;
            Assert.IsTrue(ValidateModel(produto).Count == 1);
        }

        [TestMethod]
        public void Produto_DepartamentoInformado()
        {
            Assert.IsTrue(ValidateModel(produto).Count == 0);
        }

        #endregion

        #endregion
    }
}
