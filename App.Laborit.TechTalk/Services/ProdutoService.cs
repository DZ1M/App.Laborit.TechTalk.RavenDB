using App.Laborit.TechTalk.Context;
using App.Laborit.TechTalk.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace App.Laborit.TechTalk.Services
{
    public static class ProdutoService
    {
        public static void CreateProduct(string nome, double preco)
        {
            Produto p = new Produto
            {
                Nome = nome,
                Preco = preco
            };

            using (var session = ConexaoRavenDb.Store.OpenSession())
            {
                session.Store(p);
                session.SaveChanges();
            }
        }
        public static void GetProductById(string id)
        {
            using (var session = ConexaoRavenDb.Store.OpenSession())
            {
                Produto p = session.Load<Produto>(id);
                Console.WriteLine($"Produto: {p.Nome}  \t\t Preço: {p.Preco}");
            }
        }
        public static void GetAllProducts()
        {
            using (var session = ConexaoRavenDb.Store.OpenSession())
            {
                List<Produto> all = session.Query<Produto>().ToList();
                foreach (var p in all)
                {

                    Console.WriteLine($"Produto: {p.Nome}  \t\t Preço: {p.Preco}");
                }
            }
        }
        public static void InsertMultiplesProducts(List<Produto> obj)
        {
            using (var session = ConexaoRavenDb.Store.OpenSession())
            {
                var tempo = Stopwatch.StartNew();
                foreach (var p in obj)
                {
                    session.Store(p);
                }
                session.SaveChanges();
                Console.WriteLine($"Tempo gasto: {tempo.Elapsed.TotalSeconds}");
            }
        }
    }
}
