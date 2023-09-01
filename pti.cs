/* 
Programa de Controle de Estoque de Livrarias
Versão 1.0
Autor: Victor Freire de Carvalho
Programa feito como Produção Textual Individual 
para a Disciplina de Algoritmos e Programação 2 
do curso EAD de Análise e Desenvolvimento de Sistemas
da Faculdade Senac
01/09/2023
*/

using System;
using System.Collections.Generic;

namespace EstoqueLivraria
{           
    class Program
    {
        // Classe principal do programa, com menu e ações a serem efetuadas pelo menu
        
        public static void Main(string[] args)
        {
            // Lista que armazena os livros
            List<Livro> estoque = new List<Livro>();

            int opcaoMenu = -1;
            
            Console.WriteLine("Programa de Estoque de Livrarias");
            Console.WriteLine("Versão 1.0\n");
            Console.WriteLine("Menu:\n");
            while (opcaoMenu != 0 )
            {               
                Console.WriteLine("[1] Novo Produto");
                Console.WriteLine("[2] Listar Produtos");
                Console.WriteLine("[3] Remover Produtos");
                Console.WriteLine("[4] Entrada de Estoque");
                Console.WriteLine("[5] Saída de Estoque");
                Console.WriteLine("[0] Sair\n");

                Console.WriteLine("Digite sua opção: ");
                opcaoMenu = Convert.ToInt32(Console.ReadLine());

                switch (opcaoMenu)
                {
                    case 1:
                        Console.WriteLine("Novo Produto:");
                        Console.WriteLine("Informe o nome do novo produto:");
                        string titulo = Console.ReadLine();
                        Console.WriteLine("Informe o valor do novo produto:");
                        string precoProv = Console.ReadLine();
                        float preco = float.Parse(precoProv);
                        Console.WriteLine("Informe o autor do novo produto:");
                        string autor = Console.ReadLine();
                        Console.WriteLine("Informe o gênero do novo produto:");
                        string genero = Console.ReadLine();
                        estoque.Add(new Livro(titulo, preco, autor, genero));
                        Console.WriteLine("Produto adicionado!\n");
                        break;
                    case 2:
                        foreach (Livro livro in estoque) {
                            int index = estoque.IndexOf(livro) + 1;
                            Console.WriteLine(String.Format("{0}. {1} \t Quantidade em Estoque: {2}", index, livro.titulo, livro.quantEstoque));
                        }
                        Console.WriteLine("\n");
                        break;
                    case 3:
                        Console.WriteLine("Digite a posição do item a ser removido:");
                        int posicaoRemover = Convert.ToInt32(Console.ReadLine());
                        estoque.RemoveAt(posicaoRemover - 1);
                        Console.WriteLine("\n");
                        break;
                    case 4:
                        Console.WriteLine("Digite a posição do item para adicionar entrada de estoque:");
                        int posicaoEntrou = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite quantidade de entrada:");
                        int entradaEstoque = Convert.ToInt32(Console.ReadLine());
                        estoque[posicaoEntrou - 1].quantEstoque = entradaEstoque;
                        Console.WriteLine("\n");
                        break;
                    case 5:
                        Console.WriteLine("Digite a posição do item para adicionar saída de estoque:");
                        int posicaoSaiu = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite quantidade de saída:");
                        int saidaEstoque = Convert.ToInt32(Console.ReadLine());
                        int saldoEstoque = estoque[posicaoSaiu - 1].quantEstoque - saidaEstoque;
                        if (saldoEstoque < 0) 
                        {
                            estoque[posicaoSaiu - 1].quantEstoque = 0;
                        }
                        else
                        {
                            estoque[posicaoSaiu - 1].quantEstoque = saldoEstoque;
                        }
                        Console.WriteLine("\n");
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
    // Classe Livro, que armazena os principais dados dos produtos 
    public class Livro
    {
        public string titulo { get; set; }
        public float preco { get; set; }
        public string autor { get; set; }
        public string genero { get; set; }
        public int quantEstoque { get; set; }

        public Livro(string titulo, float preco, string autor, string genero)
        {
            this.titulo = titulo;
            this.preco = preco;
            this.autor = autor;
            this.genero = genero;
            this.quantEstoque = 0;
        }

    }

}