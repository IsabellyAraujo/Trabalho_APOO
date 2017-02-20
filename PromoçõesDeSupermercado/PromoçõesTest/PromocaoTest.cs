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
            //feito
            
            //2 produtos iguais, sendo que o preço tem o valor de somente 1
            //Venda com desconto
            
            double desconto = 1.50; //50%
            //inseridos 2 produtos com codigos iguais... 
            Produto p1 = new Produto("111", "Produto 1", 2.20);
            Produto p2 = new Produto("111", "Produto 1", 2.20);
            //quantidade
            double q1 = 1.0;
            double q2 = 1.0;
            
            Venda v = new Venda(new DateTime());
            v.AdicionarItem(p1, q1);
            v.AdicionarItem(p2, q2);
            v.Desconto = desconto;
            
            double quant = q1 + q2;
            
            if(p1.Codigo == p2.Codigo && quant == 2.0){
                double totalObtido = v.GetTotal();
                //p1.preço, pois p1 é igual a p2
                Assert.AreEqual(quant * p1.Preco - desconto, totalObtido, 0.0001);
            }
        }
        
        [TestMethod]
        public void TestDesconto_1()
        {
            //3 produtos iguais "XXX", sendo que é adcionado mais um produto "Y"
            Produto p1 = new Produto("111", "Produto 1", 2.20);
            Produto p2 = new Produto("111", "Produto 1", 2.20);
            Produto p3 = new Produto("111", "Produto 1", 2.20);
            //quantidade
            double q1 = 1.0;
            double q2 = 1.0;
            double q3 = 1.0;
            
            Venda v = new Venda(new DateTime());
            v.AdicionarItem(p1, q1);
            v.AdicionarItem(p2, q2);
            v.AdicionarItem(p3, q3);       
            
            double quant = q1 + q2 + q3;
            
            if(quant == 3.0 && p1.Codigo == p2.Codigo && p2.Codigo == p3.Codigo){
                //produto sai de graça
                Produto p4 = new Produto("666", "Produto 6", 0.00);
                //quantidade
                double q4 = 1.0;
                
                double totalObtido = v.GetTotal();
                //preços iguais mais o adicionado
                Assert.AreEqual(quant * p1.Preco + q4 * p4.Preco, totalObtido, 0.0001);
        }

    }
  }
}
