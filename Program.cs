// Projeto: Sistema de Gerenciamento de Estoque
// Descrição: Projeto iniciante com a finalidade de gerenciar estoque de produtos
// Autor: Isaque Dias
// Data: 21/04/2023

using System;
using System.Text;

namespace InventoryManager
{
    class Program : Products
    {
        static void Main(String[] args)
        {
            Menu();
        }

        // Menu Principal do Sistema
        public static void Menu()
        {
            Console.Clear();

            Console.WriteLine("Menu Principal");
            Console.WriteLine("------------");

            var choices = new StringBuilder();
            choices.Append("\n1 - Cadastrar Produtos");
            choices.Append("\n2 - Consultar Produtos");
            choices.Append("\n3 - Editar Produtos");
            choices.Append("\n4 - Remover Produtos");
            choices.Append("\n5 - Sair");
            Console.WriteLine(choices);

            Console.Write("\nEscolha uma opção: ");
            var choice = int.Parse(Console.ReadLine());

            Products products = new Products();

            // Escolhendo opções da lista
            switch (choice)
            {
                case 1: products.RegisterProducts(); break;
                case 2: products.ConsultProducts(); break;
                case 3: products.EditProducts(); break;
                case 4: products.RemoveProducts(); break;
                case 5:
                    Console.Clear();
                    Console.Write("Finalizando Projeto!");
                    Thread.Sleep(1200);
                    Console.Clear();
                    Console.WriteLine("Projeto Finalizado!");
                    break;
                default:
                    Console.Clear();
                    Console.Write("Número Inválido!");
                    Thread.Sleep(1100);
                    Menu();
                    break;
            }
        }
    }
}