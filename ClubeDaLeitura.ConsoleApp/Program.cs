using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

namespace ClubeDaLeitura.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            RepositorioRevista repositorioRevista = new RepositorioRevista();
            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

            
            TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo); 
            TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);
            TelaRevista telaRevista = new TelaRevista(repositorioRevista, repositorioCaixa);
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo(repositorioAmigo, repositorioRevista);

            char opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("== Menu Principal ==");
                Console.WriteLine("1 - Gerenciar Amigos");
                Console.WriteLine("2 - Gerenciar Caixas");
                Console.WriteLine("3 - Gerenciar Revistas");
                Console.WriteLine("4 - Gerenciar Empréstimos");
                Console.WriteLine("S - Sair");
                Console.Write("Escolha uma opção: ");
                opcao = char.ToUpper(Console.ReadKey().KeyChar);

                if (opcao == '1')
                    telaAmigo.MostrarMenu();
                else if (opcao == '2')
                    telaCaixa.MostrarMenu();
                else if (opcao == '3')
                    telaRevista.MostrarMenu();
                else if (opcao == '4')
                    telaEmprestimo.MostrarMenu();

            } while (opcao != 'S');
        }
    }
}
