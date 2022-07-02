using System.Collections.Generic;
using System.Linq;
using Repository;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        
        public Produto() { }

        public Produto(
            string Nome,
            double Valor
        )
        {
            this.Nome = Nome;
            this.Valor = Valor;

            Context db = new Context();
            db.Produtos.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"\n ---------------------------------------"
                + $"\n ID: {this.Id}"
                + $"\n Nome: {this.Nome}"
                + $"\n Valor: {this.Valor}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!Produto.ReferenceEquals(this, obj))
            {
                return false;
            }
            Produto it = (Produto) obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public static void AlterarProduto(
            int Id,
            string Nome,
            double Valor
        )
        {
            Produto produto = GetProduto(Id);
            produto.Nome = Nome;
            produto.Valor = Valor;

            Context db = new Context();
            db.Produtos.Update(produto);
            db.SaveChanges();
        }


        public static IEnumerable<Produto> GetProdutos()
        {
            Context db = new Context();
            return (from Produto in db.Produtos select Produto);
        }

        public static Produto GetProduto(int Id)
        {
            Context db = new Context();
            IEnumerable<Produto> produtos = from Produto in db.Produtos
                            where Produto.Id == Id
                            select Produto;

            return produtos.First();
        }

        public static void RemoverProduto(Produto produto)
        {
            Context db = new Context();
            db.Produtos.Remove(produto);
            db.SaveChanges();
        }
    }
}