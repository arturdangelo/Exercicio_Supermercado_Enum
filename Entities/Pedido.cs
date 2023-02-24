
using Exercicio_Supermercado.Entities.Enums;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace Exercicio_Supermercado.Entities
{
    class Pedido
    {
        public Cliente Cliente { get; private set; }
        public FormaPagamento FormaPagamento { get;private set;}
        public List<Item> Items { get; private set; } = new List<Item>();
        public List<Produto> Produtos { get; private set; } = new List<Produto>();
        public DateTime HorarioPedido { get; private set; }

        public Pedido()
        {

        }
        public Pedido(Cliente cliente, FormaPagamento formaPagamento, DateTime horarioPedido)
        {
            Cliente = cliente;
            FormaPagamento = formaPagamento;
            HorarioPedido = horarioPedido;
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void RemoveItem(Item item) 
        {
            Items.Remove(item);
        }

        public double Total() 
        {
            double soma = 0.0;
            foreach(Item item in Items) 
            {
                soma += item.subTotal();
            }
            return soma;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
           
            sb.AppendLine();
            sb.AppendLine("Pedido:");
            sb.AppendLine("Cliente: " + Cliente);
            sb.AppendLine("Momento do pedido: " + HorarioPedido.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Forma de pagamento: " + FormaPagamento);
            sb.AppendLine();

            sb.AppendLine("Lista de compras:");
            foreach (Item i in Items)
            {
                sb.AppendLine(i.ToString());
            }
            
            sb.AppendLine();
            sb.AppendLine("Preço total: R$ " + Total().ToString("F2", CultureInfo.InstalledUICulture));
            sb.AppendLine("---------------------------------");
            sb.AppendLine();
            return sb.ToString();
            
        }
    }
}
