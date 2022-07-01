using System;
using System.Linq;
using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class ProdutoController
    {
        public static Produto IncluirProduto(string Nome, double Valor)
        {
            if(String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome inválido");
            }

            return new Produto(Nome, Valor);
        }

        public static Produto AlterarProduto(int Id, string Nome, double Valor)
        {
            Produto produto = GetProduto(Id);

            if(!String.IsNullOrEmpty(Nome))
            {
                Nome = produto.Nome;
            }
            
            Produto.AlterarProduto(Id, Nome, Valor);

            return produto;
        }

        public static Produto RemoverItem(int Id)
        {
            Produto produto = GetProduto(Id);
            Produto.RemoverProduto(produto);
            return produto;
        }

        public static Produto GetProduto(int Id)
        {
            Produto produto = (
                from Produto in Produto.GetProdutos()
                    where Produto.Id == Id
                    select Produto
            ).First();

            if(produto == null)
            {
                throw new Exception("Produto não encontrado");
            }

            return produto;
        }

        public static IEnumerable<Produto> VisualizarProduto()
        {
            return Produto.GetProdutos();
        }
    }
}