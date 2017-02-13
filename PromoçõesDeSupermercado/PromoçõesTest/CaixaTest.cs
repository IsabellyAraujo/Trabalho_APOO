using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace supermercado
{
    [TestClass]
    public class CaixaTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAbrirVenda_1()
        {
            Caixa c = new Caixa();
            c.AbrirVenda();
            c.AbrirVenda(); //deve gerar exceção
        }

        [TestMethod]
        public void TestEncerrarVenda_1()
        {
            var repositorioMock = new Mock<RepositorioVenda>();
            Caixa c = new Caixa();
            c.repositorioVenda = repositorioMock.Object;
            c.AbrirVenda();
            c.EncerrarVenda();
            c.AbrirVenda(); //não deve gerar exceção
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAdicionarItem_1()
        {
            var repositorioMock = new Mock<RepositorioProduto>();
            Caixa c = new Caixa();
            c.repositorioProduto = repositorioMock.Object;
            c.AbrirVenda();
            c.AdicionarItem("2213", 1.0);
        }

        [TestMethod]
        public void TestAdicionarItem_2()
        {
            string codigoProduto = "1123";
            Produto p = new Produto(codigoProduto, "Produto", 12.80);
            var repositorioMock = new Mock<RepositorioProduto>();
            repositorioMock.Setup(r => r.GetPorCodigo(codigoProduto)).Returns(p);
            Caixa c = new Caixa();
            c.repositorioProduto = repositorioMock.Object;
            c.AbrirVenda();
            c.AdicionarItem(codigoProduto, 1.0);

            IList<ItemVenda> itens = c.GetItens();

            Assert.AreEqual(1, itens.Count);
            Assert.AreEqual(p, itens[0].Produto);
        }
    }
}
