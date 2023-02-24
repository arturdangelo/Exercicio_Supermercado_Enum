using System.Globalization;
namespace Exercicio_Supermercado.Entities
{
    class Item
    {
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public double Preco { get; private set; }

        public Item()
        {

        }

        public Item (Produto produto, int quantidade, double preco)
        {
            Produto = produto;
            Quantidade = quantidade;
            Preco = preco;
        }

        public double subTotal()
        {
            return Preco * Quantidade;
        }

        public override string ToString()
        {
            return "Produto: " + Produto.Nome
                + " - Quantidade: " + Quantidade
                + " - Subtotal: R$ " + subTotal().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
