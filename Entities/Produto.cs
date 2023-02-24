using System.Globalization;
using System.Text;

namespace Exercicio_Supermercado.Entities
    
{
    class Produto
    {
        public int Cod { get; private set; }
        public string Nome { get; private set; }
        public int QtdEmEstoque { get; private set; }
        public double Preco { get; private set; }
        public Produto()
        {

        }

        public Produto (int cod, string nome, int qtdEmEstoque, double preco)
        {
            Cod = cod;
            Nome = nome;
            QtdEmEstoque = qtdEmEstoque;
            Preco = preco;
        }

        public void RemoverQtdProduto(int quantidade) 
        {
            QtdEmEstoque -= quantidade;
        }
        public override string ToString()
        {
            return "Código do Produto: "+Cod
                +" - Nome do Produto: "+Nome
                +" - Quantidade em estoque: "+QtdEmEstoque
                +" - Preço do produto: R$ "+Preco.ToString("F2", CultureInfo.InvariantCulture);               
        }
    }
}
