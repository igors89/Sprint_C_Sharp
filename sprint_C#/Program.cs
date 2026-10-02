namespace sprint_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string entrada;
            int opcao = 0;
            do
            {
                ControleUI.ExibirTitulo();
                try
                {
                    Console.Write("Escolha uma opção dentre as listadas abaixo\n\n1 - Cadastrar Novo Aluno\n2 - Cadastrar Novo Professor\n3 - Ver Informações dos Alunos\n4 - Ver Informações  dos Professores\n5 - Cadastrar Nota de Aluno\n6 - Cadastrar Turma de Professor\n7 - Calcular Média de Notas\n8 - Calcular Média de Salários\n9 - Sair\n\nInforme a opção escolhida: ");
                    entrada = Console.ReadLine();
                    if (string.IsNullOrEmpty(entrada)) throw new ArgumentNullException(null, "Não é permitido deixar o campo nulo!\n");
                    opcao = int.Parse(entrada);
                    switch (opcao)
                    {
                        case 1:
                            Gestao.Cadastrar("Aluno");
                            break;
                        case 2:
                            Gestao.Cadastrar("Professor");
                            break;
                        case 3:
                            Gestao.ListarAlunos();
                            break;
                        case 4:
                            Gestao.ListarProfessores();
                            break;
                        case 5:
                            Gestao.CadastrarNota();
                            break;
                        case 6:
                            Gestao.CadastrarTurma();
                            break;
                        case 7:
                            Gestao.CalcularMediaNotas();
                            break;
                        case 8:
                            Gestao.CalcularMediaSalarios();
                            break;
                        case 9:
                            Console.WriteLine("\nObrigado por utilizar o nosso sistema! Até a próxima!\n");
                            break;
                        default:
                            Console.WriteLine("\nERRO: Opção inválida. Por favor, tente novamente\n");
                            ControleUI.Pausa();
                            break;
                    }
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"\nERRO: {ex.Message}");
                    ControleUI.Pausa();
                    ControleUI.ExibirTitulo();
                }
                catch (FormatException)
                {
                    Console.WriteLine($"\nERRO: Formato inválido! Digite apenas números!\n");
                    ControleUI.Pausa();
                    ControleUI.ExibirTitulo();
                }

            } while (opcao != 9);
        }
    }
}
