using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace supermercado
{
    [TestClass]
    public class PromocaoTest
    {
        [TestMethod]
        public void TestDesconto_1()
        {
            //2 produtos iguais, sendo que o preço tem o valor de somente 1
            //Venda com desconto
            double desconto = 1.50; //50%
            Produto p1 = new Produto("111", "Produto 1", 2.20);
            Produto p2 = new Produto("111", "Produto 1", 2.20);
            //quantidade
            double q1 = 2.0;
            Venda v = new Venda(new DateTime());
            v.AdicionarItem(p1, q1);
            v.AdicionarItem(p2, q2);
            v.Desconto = desconto;
            
            if(q1 == 2.0 && p1.Codigo)

            double totalObtido = v.GetTotal();

            Assert.AreEqual(q1 * p1.Preco + q2 * p2.Preco - desconto, totalObtido, 0.0001);
        }

    }
  }
}
