using System.Globalization;
using System.Text.RegularExpressions;

namespace sprint_C_
{
    internal class Gestao
    {
        static private List<Aluno> ListaAlunos = [new("Igor","12312312312","12/12/2000","12123")];
        static private List<Professor> ListaProfessores = [new("Marcelo","12312312313","12/12/1996","32132",7500)];
        
        public static bool ConsultaSeExiste(string consulta)
        {
            bool existe;
            existe = ListaAlunos.Any(a => a.Nome.ToLower().Equals(consulta.ToLower()) || a.CPF == consulta || a.Matricula == consulta);
            if (!existe) existe = ListaProfessores.Any(p => p.Nome.ToLower().Equals(consulta.ToLower()) || p.CPF == consulta || p.Matricula == consulta);
            return existe;
        }

        public static void Cadastrar(string tipoCadastro)
        {
            string nome, datanascimento, cpf, matricula;
            bool datavalida,existe;
            do
            {
                Console.Clear();
                ControleUI.PreencherAsterisco(tipoCadastro == "Aluno" ? "CADASTRO DE ALUNO" : "CADASTRO DE PROFESSOR");
                Console.Write("\nInforme o nome: ");
                nome = Console.ReadLine()!.Trim();
                nome = Regex.Replace(nome,@"\s+"," ");
                existe = ConsultaSeExiste(nome);
                if (nome == "")
                {
                    Console.WriteLine("\nERRO: O nome informado é inválido! Informe um nome válido!\n");
                    ControleUI.Pausa();
                } else if (existe)
                {
                    Console.WriteLine("\nERRO: Nome já cadastrado!\n");
                    ControleUI.Pausa();
                }
            } while (nome == "" || existe);
            do {
                Console.Write("Informe o CPF (Apenas números): ");
                cpf = Console.ReadLine();
                existe = ConsultaSeExiste(cpf);
                if(cpf == "" || !Regex.IsMatch(cpf,@"^\d{11}$"))
                {
                    Console.WriteLine("\nFormato inválido!");
                } else if (existe)
                {
                    Console.WriteLine("\nERRO: CPF já cadastrado!\n");
                    ControleUI.Pausa();
                }
            } while (cpf == "" || !Regex.IsMatch(cpf.ToString(),@"^\d{11}$") || existe);
            do {
                Console.Write("Informe o número de matrícula (5 dígitos): ");
                matricula = Console.ReadLine();
                existe = ConsultaSeExiste(matricula);
                if(matricula == "" || !Regex.IsMatch(matricula,@"^\d{5}$"))
                {
                    Console.WriteLine("\nFormato invalido!");
                } else if (existe)
                {
                    Console.WriteLine("\nERRO: Matrícula já cadastrada!\n");
                    ControleUI.Pausa();
                }
            } while (matricula == "" || !Regex.IsMatch(matricula.ToString(),@"^\d{5}$") || existe);
            do
            {
                Console.Write("Informe a data de nascimento (dd/mm/aaaa): ");
                datanascimento = Console.ReadLine();
                datavalida = DateOnly.TryParseExact(datanascimento,"dd/MM/yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None, out DateOnly datafinal);
                int idade = DateTime.Now.Year - datafinal.Year;
                if (tipoCadastro == "Aluno")
                {
                    if (idade < 5)
                    {
                        Console.WriteLine("A idade mínima para aluno é 5 anos!");
                        datavalida = false;
                    }
                    else if (idade >= 90) datavalida = false;
                    if (!datavalida) Console.WriteLine("Data inválida");
                } else
                {
                    if (idade < 18){
                        Console.WriteLine("A idade mínima para professor é 18 anos!");
                        datavalida = false;
                    } else if (idade >= 65)
                    {
                        datavalida=false;
                    }
                    if(!datavalida) Console.WriteLine("Data inválida");
                }
            } while (datanascimento == "" || !datavalida);
            if(tipoCadastro == "Professor")
            {
                double salario=0;
                do
                {
                    try
                    {
                      Console.Write("Informe o salário (R$): ");
                      string entrada = Console.ReadLine();
                      if (string.IsNullOrEmpty(entrada)) throw new ArgumentNullException(null, "Não é permitido deixar o campo nulo!\n");
                      salario = double.Parse(entrada);
                      if (salario.ToString() == "" || salario<=1820)
                      {
                          Console.WriteLine("\nERRO: O salário não pode ser negativo e nem menor que um salário mínimo!\n");
                      }
                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.WriteLine($"\nERRO: {ex.Message}");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"\nERRO: Formato inválido! Digite apenas números!\n");
                    }
                } while (salario.ToString() == "" || salario<=1820);
                ListaProfessores.Add(new Professor(nome, cpf, datanascimento, matricula, salario));
                Console.WriteLine("\nProfessor cadastrado com sucesso!\n");
            }
            if (tipoCadastro == "Aluno") 
            {
                ListaAlunos.Add(new Aluno(nome, cpf, datanascimento, matricula));
                Console.WriteLine("\nAluno cadastrado com sucesso!\n");
            }
            ControleUI.Pausa();
        }
        public static void ListarAlunos()
        {
            Console.Clear();
            ControleUI.PreencherAsterisco("Lista de Alunos");
            if(ListaAlunos.Count == 0) 
            {
                Console.WriteLine("\nNão há nenhum aluno cadastrado!\n");
            }
            else {
                Console.WriteLine("\n--------------------------------");
                foreach (var aluno in ListaAlunos)
                {
                    aluno.MostrarInfo();
                }
                Console.WriteLine("--------------------------------");
            }
            ControleUI.Pausa();
        }
        public static void ListarProfessores()
        {
            Console.Clear();
            ControleUI.PreencherAsterisco("Lista de Professores");
            if(ListaProfessores.Count == 0) 
            { 
                Console.WriteLine("\nNão há nenhum professor cadastrado!\n");
            }
            else {
                Console.WriteLine("\n--------------------------------");
                foreach (var professor in ListaProfessores)
                {
                    professor.MostrarInfo();
                }
                Console.WriteLine("--------------------------------");
            }
            ControleUI.Pausa();
        }

        public static void CadastrarNota()
        {
            int escolha = 0;
            do
            {
                Console.Clear();
                ControleUI.PreencherAsterisco("Cadastrar Nota de Aluno");
                Console.WriteLine("\n---------------\nLista de Alunos\n---------------\n");
                if(ListaAlunos.Count == 0) 
                {
                    Console.WriteLine("Não há nenhum aluno cadastrado!\n");
                } else
                {
                    foreach (var aluno in ListaAlunos)
                    {
                        Console.WriteLine($"Posição {aluno.Id} => Aluno: {aluno.Nome} - Matricula: {aluno.Matricula}");
                    }
                    Console.WriteLine("\n-----------------------------------------------------------");
                    Console.Write("\n- Digite a posição do aluno que você quer cadastrar a nota: ");
                    string entrada = Console.ReadLine();
                    if (string.IsNullOrEmpty(entrada)) throw new ArgumentNullException(null, "Não é permitido deixar o campo nulo!\n");
                    escolha = int.Parse(entrada);
                    if(escolha < 0 || escolha >= ListaAlunos.Count) Console.WriteLine("\nERRO! Opção inválida!\n");
                    else
                    {
                        double nota = 0;
                        do
                        {
                            Aluno aluno = ListaAlunos[escolha];
                            Console.Write($"- Informe a nota para {aluno.Nome}: ");
                            entrada = Console.ReadLine();
                            if (string.IsNullOrEmpty(entrada)) throw new ArgumentNullException(null, "Não é permitido deixar o campo nulo!\n");
                            nota = double.Parse(entrada);
                            if(nota < 0 || nota > 10) Console.WriteLine("\nPor favor, informe uma nota válida!\n");
                            else
                            {
                                aluno.CadastrarNota(nota);
                            }
                        } while (nota < 0 || nota > 10);
                    }
                }
                ControleUI.Pausa();
            } while (escolha < 0 || escolha >= ListaAlunos.Count);
        }
        public static void CadastrarTurma()
        {
            int escolha = 0;
            do{
                Console.Clear();
                ControleUI.PreencherAsterisco("Cadastrar Turma de Professor");
                Console.WriteLine("\n--------------------\nLista de Professores\n--------------------\n");
                if(ListaProfessores.Count == 0) 
                { 
                    Console.WriteLine("Não há nenhum professor cadastrado!\n");
                } else
                {
                    foreach (var professor in ListaProfessores)
                    {
                        Console.WriteLine($"Posição {professor.Id} => Professor: {professor.Nome} - Matricula: {professor.Matricula}");
                    }
                    Console.WriteLine("\n----------------------------------------------------------------");
                    Console.Write("\n- Digite a posição do professor que você quer cadastrar a turma: ");
                    string entrada = Console.ReadLine();
                    if (string.IsNullOrEmpty(entrada)) throw new ArgumentNullException(null, "Não é permitido deixar o campo nulo!\n");
                    escolha = int.Parse(entrada);
                    if(escolha < 0 || escolha >= ListaProfessores.Count) Console.WriteLine("\nERRO! Opção inválida!\n");
                    else
                    {
                        string turma;
                        do
                        {
                            Professor p = ListaProfessores[escolha];
                            Console.Write($"- Informe a turma* que quer cadastrar para o(a) professor(a) {p.Nome}\n*O nome da turma deve conter 2 letras para o bairro, 1 letra para o turno (M, T ou N) e um número\n- Turma: ");
                            turma = Console.ReadLine()!.Trim();
                            turma = Regex.Replace(turma,@"\s+","");
                            if(turma == "" || turma == null) Console.WriteLine("\nNada foi informado!\n");
                            else if(!Regex.IsMatch(turma,@"^[a-zA-Z]{2}[mntMTN][1-9]$")) Console.WriteLine("\nO nome da turma não está no formato solicitado!\n");
                            
                            else
                            {
                                p.CadastrarTurma(turma.ToUpper());
                            }
                        } while (turma == "" || turma == null || !Regex.IsMatch(turma,@"^[a-zA-Z]{2}[mntMTN][1-9]$"));
                    }
                }
                ControleUI.Pausa();
            } while (escolha < 0 || escolha >= ListaProfessores.Count);
        }

        public static void CalcularMediaNotas()
        {
            int escolha = 0;
            do
            {
                Console.Clear();
                ControleUI.PreencherAsterisco("Calcular Média das Notas");
                Console.WriteLine("\n---------------\nLista de Alunos\n---------------\n");
                if(ListaAlunos.Count == 0) 
                {
                    Console.WriteLine("Não há nenhum aluno cadastrado!\n");
                } else
                {
                    foreach (var aluno in ListaAlunos)
                    {
                        Console.WriteLine($"Posição {aluno.Id} => Aluno: {aluno.Nome} - Matricula: {aluno.Matricula}");
                    }
                    Console.WriteLine("\n-----------------------------------------------------------");
                    Console.Write("\n- Digite a posição do aluno que você quer calcular a média: ");
                    string entrada = Console.ReadLine();
                    if (string.IsNullOrEmpty(entrada)) throw new ArgumentNullException(null, "Não é permitido deixar o campo nulo!\n");
                    escolha = int.Parse(entrada);
                    if(escolha < 0 || escolha >= ListaAlunos.Count) Console.WriteLine("\nERRO! Opção inválida!\n");
                    else
                    {
                        Aluno aluno = ListaAlunos[escolha];
                        double media = aluno.CalcularMedia();
                        if(media == -1) Console.WriteLine($"\n- O(A) aluno(a) {aluno.Nome} não possui nenhuma nota cadastrada!\n");
                        else Console.WriteLine($"\n- A média das notas do(a) aluno(a) {aluno.Nome} é {media:F1}!\n");
                    }
                }
                ControleUI.Pausa();
            } while (escolha < 0 || escolha >= ListaAlunos.Count);
        }

        public static void CalcularMediaSalarios()
        {
            Console.Clear();
            ControleUI.PreencherAsterisco("Calcular média dos salários");
            if (ListaProfessores.Count == 0)
            {
                Console.WriteLine("\nNão existe nenhum cadastro de professor!\n");
            } else
            {
                double mediaSalarios = ListaProfessores.Average(p => p.Salario);
                Console.WriteLine($"\nA média dos salários dos professores é R${mediaSalarios} reais!\n");
            }
            ControleUI.Pausa();
        }
    }
}