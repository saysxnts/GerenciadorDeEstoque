// Program.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

// A classe 'Produto' precisa estar visível aqui. Se você a colocou em outro
// namespace, precisará adicionar o 'using' correspondente.
// Mas se estiver no mesmo projeto, geralmente funciona sem 'using' adicional.

class Program
{
    // Lista para guardar nosso estoque em memória
    static List<Produto> estoque = new List<Produto>();
    // Caminho do arquivo onde o estoque será salvo
    static string arquivoDeEstoque = "estoque.json";

    static void Main(string[] args)
    {
        CarregarEstoque(); // Carrega os dados do arquivo ao iniciar

        bool sair = false;
        while (!sair)
        {
            Console.WriteLine("\n--- Sistema de Gerenciamento de Estoque ---");
            Console.WriteLine("1. Adicionar Produto");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("3. Atualizar Quantidade");
            Console.WriteLine("4. Remover Produto");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AdicionarProduto();
                    break;
                case "2":
                    ListarProdutos();
                    break;
                case "3":
                    AtualizarQuantidade();
                    break;
                case "4":
                    RemoverProduto();
                    break;
                case "5":
                    sair = true;
                    SalvarEstoque(); // Salva os dados no arquivo ao sair
                    Console.WriteLine("Estoque salvo. Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    static void CarregarEstoque()
    {
        // Verifica se o arquivo de estoque existe
        if (File.Exists(arquivoDeEstoque))
        {
            string json = File.ReadAllText(arquivoDeEstoque);
            // Desserializa o JSON para a nossa lista de produtos
            estoque = JsonSerializer.Deserialize<List<Produto>>(json);
            Console.WriteLine("Estoque carregado com sucesso!");
        }
        else
        {
            Console.WriteLine("Nenhum arquivo de estoque encontrado. Começando com um estoque vazio.");
            estoque = new List<Produto>();
        }
    }

    static void SalvarEstoque()
    {
        // Configurações para o JSON ficar bem formatado (indentado)
        var options = new JsonSerializerOptions { WriteIndented = true };
        // Serializa nossa lista de produtos para uma string JSON
        string json = JsonSerializer.Serialize(estoque, options);
        // Escreve a string JSON no nosso arquivo
        File.WriteAllText(arquivoDeEstoque, json);
    }

    static void AdicionarProduto()
    {
        Console.Write("Nome do Produto: ");
        string nome = Console.ReadLine();
        Console.Write("Quantidade inicial: ");
        int quantidade = int.Parse(Console.ReadLine());
        Console.Write("Preço: ");
        decimal preco = decimal.Parse(Console.ReadLine());

        // Gera um ID único simples (o maior ID atual + 1, ou 1 se a lista estiver vazia)
        int novoId = estoque.Any() ? estoque.Max(p => p.Id) + 1 : 1;

        estoque.Add(new Produto { Id = novoId, Nome = nome, Quantidade = quantidade, Preco = preco });
        Console.WriteLine("Produto adicionado com sucesso!");
    }

    static void ListarProdutos()
    {
        Console.WriteLine("\n--- Lista de Produtos no Estoque ---");
        if (!estoque.Any())
        {
            Console.WriteLine("O estoque está vazio.");
            return;
        }

        foreach (var produto in estoque)
        {
            Console.WriteLine($"ID: {produto.Id} | Nome: {produto.Nome} | Quantidade: {produto.Quantidade} | Preço: R${produto.Preco:F2}");
        }
    }

    static void AtualizarQuantidade()
    {
        Console.Write("Digite o ID do produto para atualizar: ");
        int id = int.Parse(Console.ReadLine());

        // Encontra o produto na lista com o ID fornecido
        Produto produtoParaAtualizar = estoque.FirstOrDefault(p => p.Id == id);

        if (produtoParaAtualizar == null)
        {
            Console.WriteLine("Produto não encontrado.");
            return;
        }

        Console.Write($"Digite a nova quantidade para '{produtoParaAtualizar.Nome}': ");
        int novaQuantidade = int.Parse(Console.ReadLine());
        produtoParaAtualizar.Quantidade = novaQuantidade;
        Console.WriteLine("Quantidade atualizada com sucesso!");
    }

    static void RemoverProduto()
    {
        Console.Write("Digite o ID do produto para remover: ");
        int id = int.Parse(Console.ReadLine());

        Produto produtoParaRemover = estoque.FirstOrDefault(p => p.Id == id);

        if (produtoParaRemover == null)
        {
            Console.WriteLine("Produto não encontrado.");
            return;
        }

        estoque.Remove(produtoParaRemover);
        Console.WriteLine($"Produto '{produtoParaRemover.Nome}' removido com sucesso!");
    }
}