using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace supermercado
{
    [TestClass]
    public class VendaTest
    {
        [TestMethod]
        public void TestGetTotal_1()
        {
            //Venda sem desconto
            Produto p1 = new Produto("1", "Produto 1", 5.50);
            double q1 = 3.0;
            Produto p2 = new Produto("2", "Produto 2", 2.20);
            double q2 = 1.0;
            Venda v = new Venda(new DateTime());
            v.AdicionarItem(p1, q1);
            v.AdicionarItem(p2, q2);

            double totalObtido = v.GetTotal();

            Assert.AreEqual(q1 * p1.Preco + q2 * p2.Preco, totalObtido, 0.0001);
        }

        [TestMethod]
        public void TestGetTotal_2()
        {
            //Venda com desconto
            double desconto = 2.30;
            Produto p1 = new Produto("1", "Produto 1", 5.50);
            double q1 = 3.0;
            Produto p2 = new Produto("2", "Produto 2", 2.20);
            double q2 = 1.0;
            Venda v = new Venda(new DateTime());
            v.AdicionarItem(p1, q1);
            v.AdicionarItem(p2, q2);
            v.Desconto = desconto;

            double totalObtido = v.GetTotal();

            Assert.AreEqual(q1 * p1.Preco + q2 * p2.Preco - desconto, totalObtido, 0.0001);
        }
    }
}
