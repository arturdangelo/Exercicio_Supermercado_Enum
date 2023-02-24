

namespace Exercicio_Supermercado.Entities
{
    class Cliente
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }

        public Cliente() 
        {

        }

        public Cliente (string nome, string cPF)
        {
            Nome = nome;
            CPF = cPF;
        }

        public override string ToString()
        {
            return "Nome: " + Nome + " - CPF: " + CPF;
 
        }
    }
}
