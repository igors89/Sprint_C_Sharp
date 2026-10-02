namespace sprint_C_
{
    public class ControleUI
    {
        public static void PreencherAsterisco(string texto)
        {
            int tamanho = texto.Length;
            string asterisco = string.Empty.PadLeft(tamanho,'*');
            Console.WriteLine($"{asterisco}\n{texto}\n{asterisco}");
        }

        public static void ExibirTitulo()
        {
            
            Console.Clear();
            Console.WriteLine(@"
░█████╗░░█████╗░░█████╗░██████╗░███████╗███╗░░░███╗██╗░░░██╗░░░██╗░█████╗░
██╔══██╗██╔══██╗██╔══██╗██╔══██╗██╔════╝████╗░████║╚██╗░██╔╝░░░██║██╔══██╗
███████║██║░░╚═╝███████║██║░░██║█████╗░░██╔████╔██║░╚████╔╝░░░░██║██║░░██║
██╔══██║██║░░██╗██╔══██║██║░░██║██╔══╝░░██║╚██╔╝██║░░╚██╔╝░░░░░██║██║░░██║
██║░░██║╚█████╔╝██║░░██║██████╔╝███████╗██║░╚═╝░██║░░░██║░░░██╗██║╚█████╔╝
╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝╚═════╝░╚══════╝╚═╝░░░░░╚═╝░░░╚═╝░░░╚═╝╚═╝░╚════╝░" + "\n");

            PreencherAsterisco("Seja bem vindo ao Academy.io, o sistema inteligente de gestão acadêmica!");
            Console.WriteLine("\n");
        }

        public static void Pausa()
        {
            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
        }
    }
}