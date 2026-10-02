using sprint_C_.models;
namespace sprint_C_
{
    internal class Professor : Pessoa, IMostrarInfo
    {
        private List<string> listaTurma = [];
        private static int contador = 0;
        public double Salario { get; private set; }
        public string Matricula { get; private set; }
        public int Id { get; }
        public int QtdTurmas() => listaTurma.Count();

        public Professor(string nome, string cpf, string datanascimento, string matricula, double salario) : base(nome, cpf, datanascimento)
        {
            Salario = salario;
            Matricula = matricula;
            Id = contador++;
        }

        public override void MostrarLista()
        {
            Console.WriteLine("---------------");
            base.MostrarLista();
            Console.WriteLine("Turmas");
            Console.WriteLine("---------------");
            if (QtdTurmas() == 0) Console.WriteLine("Não há nenhuma turma cadastrada\n");
            else
            {
                Console.WriteLine(string.Join(", ",listaTurma));
                Console.WriteLine();
            }
        }
        public void MostrarInfo()
        {
            Console.WriteLine($"\n{Id}) Professor: {Nome} - Matrícula: {Matricula} - CPF: {CPF} - Salário: R${Salario:F2}\n");
            MostrarLista();
        }
        public void CadastrarTurma(string turma)
        {
            if(listaTurma.Any(t => t.ToLower().Equals(turma.ToLower()))) Console.WriteLine("\nEssa turma já está cadastrada para esse professor! Tente novamente!\n");
            else
            {
                listaTurma.Add(turma);
                Console.WriteLine("\nTurma cadastrada com sucesso!\n");
            }
        }
        
    }
}
