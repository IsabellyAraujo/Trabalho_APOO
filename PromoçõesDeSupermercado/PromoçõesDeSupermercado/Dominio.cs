using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace supermercado
{
    public class Produto
    {
        private string codigo;
        public string Codigo
        {
            get { return codigo;  }
        }
        private string descricao;
        public string Descricao {
            get { return descricao;  }
        }
        public double Preco { get; set; }

        public Produto(string codigo, string descricao, double preco)
        {
            this.codigo = codigo;
            this.descricao = descricao;
            this.Preco = preco;
        }
    }

    public class ItemVenda
    {
        private Produto produto;
        public Produto Produto {
            get { return produto;  }
        }
        private double quantidade;
        public double Quantidade {
            get { return quantidade;  }
        }
        public double Subtotal {
            get { return produto.Preco * quantidade; } 
        }

        public ItemVenda(Produto produto, double quantidade)
        {
            this.produto = produto;
            this.quantidade = quantidade;
        }
    }

    public class Venda
    {
        private DateTime dataHora;
        public DateTime DataHora
        {
            get { return dataHora; }
        }
        private IList<ItemVenda> itens = new List<ItemVenda>();
        public IList<ItemVenda> Itens
        {
            get { return new List<ItemVenda>(itens); }
        }
        private double desconto = 0.0;
        public double Desconto
        {
            get { return desconto; }
            set { desconto = value; }
        }
        public Venda(DateTime dataHora)
        {
            this.dataHora = dataHora;
        }

        public ItemVenda AdicionarItem(Produto produto, double quantidade)
        {
            ItemVenda item = new ItemVenda(produto, quantidade);
            itens.Add(item);
            return item;
        }
        
        public double GetTotal()
        {
            double total = 0.0;
            foreach(ItemVenda item in itens)
            {
                total += item.Subtotal;
            }
            return total - desconto;
        }
    }

    public class Caixa
    {
        private Venda vendaCorrente;
        public RepositorioVenda repositorioVenda;
        public RepositorioProduto repositorioProduto;

        public void AbrirVenda()
        {
            if (vendaCorrente != null)
                throw new InvalidOperationException("Já existe uma venda em curso");
            vendaCorrente = new Venda(DateTime.Now);
        }
        
        public double CalcularDesconto()
        {
            return 0.0;
        }

        public double GetTotalSemDesconto()
        {
            return vendaCorrente.GetTotal();
        }

        public void EncerrarVenda()
        {
            vendaCorrente.Desconto = CalcularDesconto();
            repositorioVenda.Salvar(vendaCorrente);
            vendaCorrente = null;
        }

        public void AdicionarItem(string codigoProduto, double quantidade)
        {
            if (vendaCorrente == null)
                throw new InvalidOperationException("Não há venda corrente");
            Produto produto = repositorioProduto.GetPorCodigo(codigoProduto);
            if (produto == null)
                throw new ArgumentException("Produto não encontrado");

            vendaCorrente.AdicionarItem(produto, quantidade);
        }

        public IList<ItemVenda> GetItens()
        {
            if (vendaCorrente == null)
                throw new InvalidOperationException("Não há venda corrente");
            return vendaCorrente.Itens;
        }
    }
    public interface RepositorioVenda
    {
        void Salvar(Venda v);
    }
    public interface RepositorioProduto
    {
        //Deve retornar nulo caso o produto não seja encontrado
        Produto GetPorCodigo(string codigoProduto);
    }
}
