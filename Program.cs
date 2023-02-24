using Exercicio_Supermercado.Entities;
using Exercicio_Supermercado.Entities.Enums;
using System.Globalization;

namespace Exercicio_Supermercado
{
    class program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Informe a quantidade de produtos a serem cadastrados:");
            int x = int.Parse(Console.ReadLine());

            List<Produto> produto = new List<Produto>();
            for (int i = 1; i <= x; i++)
            {
                int codProd = i;

                Console.WriteLine($"Código {i}");
                Console.WriteLine("Insira o nome do produto:");
                string nomeProd = Console.ReadLine();

                Console.WriteLine("Insira a quantidade do produto:");
                int qtdEmEstoque = int.Parse(Console.ReadLine());

                Console.WriteLine("Insira o preço do produto:");
                double precoProd = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                produto.Add(new Produto(codProd, nomeProd, qtdEmEstoque, precoProd));

            }

            Console.WriteLine();
            foreach (Produto obj in produto)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine();
            Console.WriteLine("Informe o nome do cliente:");
            string nomeCliente = Console.ReadLine();

            Console.WriteLine("Informe o CPF do cliente:");
            string CPF = Console.ReadLine();

            Cliente cliente = new Cliente(nomeCliente, CPF);

            Console.WriteLine();
            Console.WriteLine("Forma de pagamento (Cartao/Dinheiro):");
            FormaPagamento formaPagamento = Enum.Parse<FormaPagamento>(Console.ReadLine());

            Pedido pedido = new Pedido(cliente, formaPagamento, DateTime.Now);

            Console.WriteLine();
            Console.WriteLine("Informe a quantidade de itens:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Produtos:");
            Console.WriteLine();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Insira o código do produto:");
                int aux = int.Parse(Console.ReadLine());

                //Pesquisando se o código existe
                Produto p = produto.Find(x => x.Cod == aux);

                //Caso o código não existir, repetir a pesquisa
                while (p == null)
                {
                    Console.WriteLine("Produto não encontrado!");
                    Console.WriteLine("Insira o código do produto");
                    aux = int.Parse(Console.ReadLine());
                    p = produto.Find(x => x.Cod == aux);
                }

                while (p.QtdEmEstoque == 0)
                {
                    Console.WriteLine("Estoque zerado! Favor informar outro produto");
                    aux = int.Parse(Console.ReadLine());
                    p = produto.Find(x => x.Cod == aux);
                }

                Console.WriteLine("Insira a quantidade a ser comprada:");
                int qtd = int.Parse(Console.ReadLine());

                while (qtd > p.QtdEmEstoque)
                {
                    Console.WriteLine("Quantidade informada maior que em estoque");
                    Console.WriteLine("Insira a quantidade a ser comprada:");
                    qtd = int.Parse(Console.ReadLine());
                }

                //p é o produto a ser passado no construtor da classe Item// p.Preco vem do preço do produto da classe Produto
                Item item = new Item(p, qtd, p.Preco);
                pedido.AddItem(item);

                p.RemoverQtdProduto(qtd);
            }

            Console.WriteLine();
            Console.WriteLine(pedido);

            Console.WriteLine();
            Console.WriteLine("Produtos atualizados:");
            foreach (Produto obj in produto)
            {
                Console.WriteLine(obj);
            }
        }
    }
}

