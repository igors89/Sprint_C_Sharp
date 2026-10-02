using sprint_C_.models;
namespace sprint_C_
{
    internal class Aluno : Pessoa, IMostrarInfo
    {
        private List<double> notas = [];
        private static int contador=0;
        public string Matricula { get; private set; }
        public int Id { get; private set; }
        public int QtdNotas() => notas.Count();

        public Aluno(string nome, string cpf, string datanascimento, string matricula):base(nome,cpf,datanascimento)
        {
            Matricula = matricula;
            Id = contador++;
        }

        public override void MostrarLista()
        {
            Console.WriteLine("--------------");
            base.MostrarLista();
            Console.WriteLine("Notas");
            Console.WriteLine("--------------");
            if (QtdNotas() == 0) Console.WriteLine("Não há nenhuma nota cadastrada\n");
            else
            {
                Console.WriteLine(string.Join(", ",notas));
                Console.WriteLine();
            }
        }
        public void MostrarInfo()
        {
            Console.WriteLine($"\n{Id}) Aluno: {Nome} - Matrícula: {Matricula} - CPF: {CPF}\n");
            MostrarLista();
        }
        public void CadastrarNota(double nota)
        {
            notas.Add(nota);
            Console.WriteLine("\nNota cadastrada com sucesso!\n");
        }
        public double CalcularMedia()
        {
            if (QtdNotas() == 0)
            {
                return -1;
            }
            else
            {
                return notas.Average();
            }
        }
    }
}
