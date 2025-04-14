using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TelaAmigo telaAmigo = new TelaAmigo();
            TelaCaixa telaCaixa = new TelaCaixa();
            TelaRevista telaRevista = new TelaRevista();

            char opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("== Menu Principal ==");
                Console.WriteLine("1 - Gerenciar Amigos");
                Console.WriteLine("2 - Gerenciar Caixas");
                Console.WriteLine("3 - Gerenciar Revistas");
                Console.WriteLine("S - Sair");
                Console.Write("Escolha uma opção: ");
                opcao = char.ToUpper(Console.ReadKey().KeyChar);

                if (opcao == '1')
                    telaAmigo.MostrarMenu();  // Chama o menu de Amigos
                else if (opcao == '2')
                    telaCaixa.MostrarMenu();  // Chama o menu de Caixas
                else if (opcao == '3')
                    telaRevista.MostrarMenu();  // Chama o menu de Revistas

            } while (opcao != 'S');
        }
    }
}
