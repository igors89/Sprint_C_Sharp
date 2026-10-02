namespace sprint_C_
{
    internal abstract class Pessoa
    {
        protected Pessoa(string nome, string cpf, string datanascimento)
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = datanascimento;
        }

        public string Nome { get; }
        public string CPF { get; }
        public string DataNascimento { get; }
        public virtual void MostrarLista()
        {
            Console.Write("Lista de ");
        }
    }
}
