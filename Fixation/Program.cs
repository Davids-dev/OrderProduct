using System;
using Fixation.Entities;
using Fixation.Entities.Enums;
using System.Collections.Generic;
using System.Globalization;


namespace Fixation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birth = DateTime.Parse(Console.ReadLine()); //quando quiser ler uma data utilizo o Datetime time = DateTime.Parse(Console.ReadLine());
            Client client = new Client(name, email, birth); //instanciei meu objeto Cliente com suas caracteristicas

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine()); //tipo enumerado, vai receber o status do pedido em string, vai converter para Enum
            Order order = new Order(status, client); //do meu cliente, ele vai associar o seu nome
            Console.Write("How many items to this order?" );
            int qtdeItems = int.Parse(Console.ReadLine());

            OrderItem orderItem = new OrderItem();
            for (int i = 1; i <= qtdeItems; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product Name: ");
                string prodName = Console.ReadLine();
                Console.Write("Product Price: ");
                double prodPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int prodQtde = int.Parse(Console.ReadLine());

                Product product = new Product(prodName, prodPrice); //instanciei um objeto do tipo Produto recebendo suas caracteristicas
                orderItem = new OrderItem(prodQtde, prodPrice, product); //instanciei um objeto do tipo OrderItem(itens do pedido) com seus atributos/caracteristicas
                order.AddItem(orderItem);// adicionei a minha lista de pedidos o meu objeto
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMARY: ");
            Console.WriteLine(order);


            


        }
    }
}
