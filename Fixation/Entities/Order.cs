using System;
using System.Collections.Generic;
using System.Text;
using Fixation.Entities.Enums;
using System.Globalization;

namespace Fixation.Entities
{
    class Order
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }

        public Order()
        {
        }

        public Order(OrderStatus status, Client client)
        {
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double total = 0.0;

            foreach (OrderItem obj in Items) //para cada item obj em Items 
            {
                total += obj.SubTotal(); //vou somar o total + o valor do Item
            }
            return total;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order Moment: ");
            sb.Append(Date.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine();
            sb.Append("Order Status: ");
            sb.Append(Status);
            sb.AppendLine();
            sb.Append("Client: "); /// CONSIGO FAZER BUSCAR OS ATRIBUTOS ATRAVÉS DAS ASSOCIAÇÕES QUE EU TENHO NA MINHA CLASSE
            sb.Append(Client.Name);
            sb.Append(" ");
            sb.Append(Client.Date); /// CONSIGO FAZER BUSCAR OS ATRIBUTOS ATRAVÉS DAS ASSOCIAÇÕES QUE EU TENHO NA MINHA CLASSE
            sb.Append(" - ");
            sb.Append(Client.Email); /// CONSIGO FAZER BUSCAR OS ATRIBUTOS ATRAVÉS DAS ASSOCIAÇÕES QUE EU TENHO NA MINHA CLASSE
            sb.AppendLine(); 
            sb.AppendLine("Order items: ");
            sb.AppendLine();



            //para cada item dentro da minha lista Items
            foreach (OrderItem item in Items)
            {
                sb.Append(item.Product.Name); /// CONSIGO FAZER BUSCAR OS ATRIBUTOS ATRAVÉS DAS ASSOCIAÇÕES QUE EU TENHO NA MINHA CLASSE
                sb.Append(", ");
                sb.Append(item.Product.Price.ToString("F2", CultureInfo.InvariantCulture)); 
                sb.Append(", Quantity: ");
                sb.Append(item.Quantity);
                sb.Append(", Subtotal: $");
                sb.Append(item.Price);
                sb.AppendLine();
            }

            sb.Append("Total price: $");
            sb.Append(Total().ToString("F2", CultureInfo.InvariantCulture));
            //CORRIGIR O TO STRING TOTAL PRICE, ESTÁ APARCENDO O TOTAL DUAS VEZES


            return sb.ToString();
        }
    }
}
