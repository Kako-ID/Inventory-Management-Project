using System;
using System.Threading;
using System.Collections.Generic;

namespace InventoryManager
{
    class InformationProducts
    {
        public string nameProduct { get; set; }

        public double quantityProduct { get; set; }

        public double weightProduct { get; set; }

        public double priceProduct { get; set; }

        public string descriptionProduct { get; set; }
    }

    class Products
    {
        // Lista para Armazenamento de Informações dos Produtos
        static List<InformationProducts> infoProducts = new List<InformationProducts>();

        int count = 0;

        public void RegisterProducts()
        {
            Console.Clear();

            // Loop para cadastrar os produtos enquanto o usuário desejar
            do
            {
                InformationProducts info = new InformationProducts();

                Console.Write("Nome do Produto: ");
                info.nameProduct = Console.ReadLine().ToUpper();

                Console.Write("Quantidade em Estoque: ");
                info.quantityProduct = int.Parse(Console.ReadLine().ToUpper());

                Console.Write("Preço do Produto: ");
                info.priceProduct = double.Parse(Console.ReadLine().ToUpper());

                Console.Write("Peso do Produto: ");
                info.weightProduct = double.Parse(Console.ReadLine().ToUpper());

                Console.Write("Descrição do Produto: ");
                info.descriptionProduct = Console.ReadLine();

                infoProducts.Add(info); // Adicionando as informações do produtos na lista

                Console.Clear();
                Console.Write("Deseja cadastrar mais Produtos? [S/N]: ");
                var proceed = Console.ReadLine().ToUpper();

                if (proceed == "S")
                {
                    Console.Clear();
                    RegisterProducts();
                }
                else
                {
                    break;
                }
            } while (true);

            Program.Menu(); // Volta ao Menu Principal
        }

        public void ConsultProducts()
        {
            Console.Clear();

            Console.Write("Consultando Lista de Produtos!");
            Thread.Sleep(1100);

            Console.Clear();

            if (infoProducts.Count == 0)
            {
                Console.WriteLine("Nenhum Produto Cadastrado!");
                Thread.Sleep(1100);
                Program.Menu();
            }
            else
            {
                foreach (var item in infoProducts)
                {
                    // Exibe as informações dos produtos cadastrados na lista infoProducts
                    Console.WriteLine("Nome do Produto: {0}", item.nameProduct);
                    Console.WriteLine("Quantidade em Estoque: {0}", item.quantityProduct);
                    Console.WriteLine("Preço do Produto: R$ {0}", item.priceProduct);
                    Console.WriteLine("Peso do Produto: {0} kg", item.weightProduct);
                    Console.WriteLine("Descrição do Produto: {0}", item.descriptionProduct);
                    Console.WriteLine("------------------------------------");
                }
            }

            Console.Write("\nPressione Enter...");
            Console.ReadKey();

            Program.Menu();
        }

        public void EditProducts()
        {
            Console.Clear();
            Console.Write("Informe o nome do Produto que deseja alterar: ");
            string runProduct = Console.ReadLine().ToUpper();

            // Localiza o produto na lista 
            InformationProducts editProduct = infoProducts.Find(product => product.nameProduct == runProduct);

            if (editProduct != null)
            {
                Console.Clear();
                Console.Write("Digite o novo nome do produto: ");
                string newNameProduct = Console.ReadLine().ToUpper();

                Console.Write("Digite a nova quantidade em estoque: ");
                double newQuantityProduct = double.Parse(Console.ReadLine());

                Console.Write("Digite o novo preço do produto: ");
                double newPriceProduct = double.Parse(Console.ReadLine());

                Console.Write("Digite o novo peso do produto: ");
                double newWeightProduct = double.Parse(Console.ReadLine());

                Console.Write("Digite a nova descrição do produto: ");
                string newDescriptionProduct = Console.ReadLine();

                // Atualiza as propriedades do produto
                editProduct.nameProduct = newNameProduct;
                editProduct.quantityProduct = newQuantityProduct;
                editProduct.priceProduct = newPriceProduct;
                editProduct.weightProduct = newWeightProduct;
                editProduct.descriptionProduct = newDescriptionProduct;

                Console.Clear();
                Console.WriteLine("Produto editado com sucesso!");
                Thread.Sleep(1100);

                Program.Menu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Produto não encontrado na lista.");
                Thread.Sleep(1100);
            }

            Program.Menu();
        }

        public void RemoveProducts()
        {
            Console.Clear();
            Console.Write("Informe o nome do Produto que deseja remover: ");

            string runProduct = Console.ReadLine().ToUpper();

            // Localizando o Produto na lista
            InformationProducts removeProduct = infoProducts.Find(product => product.nameProduct == runProduct);

            if (removeProduct != null)
            {
                Console.Clear();
                infoProducts.Remove(removeProduct);

                Console.WriteLine("Produto Removido com sucesso!");
                Console.Write("Pressione Enter...");
                Console.ReadKey();

                Program.Menu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Produto não encontrado na lista!");
            }

            Console.Write("Pressione Enter...");
            Console.ReadKey();

            Program.Menu();
        }
    }
}