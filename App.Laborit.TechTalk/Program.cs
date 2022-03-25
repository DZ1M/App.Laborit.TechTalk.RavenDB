using App.Laborit.TechTalk.Models;
using App.Laborit.TechTalk.Services;
using System;
using System.Collections.Generic;

namespace App.Laborit.TechTalk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Iniciar();
        }
        private static void Iniciar()
        {
            Console.WriteLine("0 - CRIAR Produto");
            Console.WriteLine("1 - Visualziar Produtos");
            Console.WriteLine("2 - Visualziar Produtos Por ID");
            Console.WriteLine("3 - Inserir Multiplos Produtos");
            Console.WriteLine("---------------------------- \n");

            var opcao = Convert.ToInt32(Console.ReadLine());
            switch (opcao)
            {
                case 0:
                    CriarProduto();
                    break;
                case 1:
                    ProdutoService.GetAllProducts();
                    Iniciar();
                    break;
                case 2:
                    BuscarPorId();
                    break;
                case 3:
                    InsertAll();
                    break;
                default:
                    break;
            }
        }
        private static void CriarProduto()
        {
            Console.WriteLine("Digite o nome do produto: ");
            var nomeProduto = Console.ReadLine();
            Console.WriteLine("Digite o preço do produto: ");
            var precoProduto = Convert.ToDouble(Console.ReadLine());
            ProdutoService.CreateProduct(nomeProduto, precoProduto);

            Console.WriteLine("Produtos inseridos.");
            Iniciar();
        }

        private static void BuscarPorId()
        {
            Console.WriteLine("Informe o id do produto:");
            var id = Console.ReadLine();
            ProdutoService.GetProductById(id);
            Iniciar();
        }
        private static void InsertAll()
        {
            var randon = new Random();
            var produtos = new List<Produto>();
            for (int i = 0; i < 1000; i++)
            {
                produtos.Add(new Produto
                {
                    Preco = randon.NextDouble(),
                    Nome = $"Auto Insert {i}"
                });
            }
            ProdutoService.InsertMultiplesProducts(produtos);
            Iniciar();
        }
    }
}
