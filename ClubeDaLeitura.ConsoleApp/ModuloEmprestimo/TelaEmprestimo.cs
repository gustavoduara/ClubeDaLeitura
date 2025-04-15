using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class TelaEmprestimo
    {
        public RepositorioEmprestimo repositorio = new RepositorioEmprestimo();
        public RepositorioAmigo repositorioAmigo;
        public RepositorioRevista repositorioRevista;

        public TelaEmprestimo(RepositorioAmigo amigos, RepositorioRevista revistas)
        {
            this.repositorioAmigo = amigos;
            this.repositorioRevista = revistas;
        }

        public void MostrarMenu()
        {
            char opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("== Clube da Leitura - Empréstimos ==");
                Console.WriteLine("1 - Registrar novo empréstimo");
                Console.WriteLine("2 - Registrar devolução");
                Console.WriteLine("3 - Visualizar empréstimos");
                Console.WriteLine("S - Voltar");
                Console.Write("Opção: ");
                opcao = char.ToUpper(Console.ReadKey().KeyChar);

                if (opcao == '1')
                    RegistrarEmprestimo();
                else if (opcao == '2')
                    RegistrarDevolucao();
                else if (opcao == '3')
                    ListarEmprestimos();

            } while (opcao != 'S');
        }

        public void RegistrarEmprestimo()
        {
            Console.Clear();
            Console.WriteLine("-- Registrar novo empréstimo --");

            // Listar amigos
            Console.WriteLine("Amigos cadastrados:");
            for (int i = 0; i < repositorioAmigo.contador; i++)
            {
                Amigo a = repositorioAmigo.amigos[i];
                Console.WriteLine($"{a.Id} - {a.Nome}");
            }

            Console.Write("Digite o ID do amigo: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());
            Amigo amigoEscolhido = repositorioAmigo.amigos.FirstOrDefault(a => a != null && a.Id == idAmigo);

            // Listar revistas
            Console.WriteLine("Revistas cadastradas:");
            for (int i = 0; i < repositorioRevista.contador; i++)
            {
                Revista r = repositorioRevista.revistas[i];
                Console.WriteLine($"{r.Id} - {r.Nome}");
            }

            Console.Write("Digite o ID da revista: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());
            Revista revistaEscolhida = repositorioRevista.revistas.FirstOrDefault(r => r != null && r.Id == idRevista);

            DateTime dataEmprestimo = DateTime.Now;
            DateTime dataDevolucao = dataEmprestimo.AddDays(7); // por exemplo, 7 dias depois

            int id = repositorio.contador + 1;

            Emprestimo novo = new Emprestimo(id, amigoEscolhido, revistaEscolhida, dataEmprestimo, dataDevolucao);

            repositorio.Inserir(novo);

            Console.WriteLine("Empréstimo registrado com sucesso!");
            Console.ReadKey();
        }

        public void ListarEmprestimos()
        {
            Console.Clear();
            Console.WriteLine("-- Lista de empréstimos --");

            Emprestimo[] lista = repositorio.Listar();

            for (int i = 0; i < repositorio.contador; i++)
            {
                Emprestimo e = lista[i];
                Console.WriteLine($"ID: {e.Id} | Amigo: {e.Amigo.Nome} | Revista: {e.Revista.Nome} | Devolução: {e.DataDevolucao:dd/MM/yyyy}");
            }

            Console.ReadKey();
        }

        public void RegistrarDevolucao()
        {
            Console.Clear();
            Console.WriteLine("-- Registrar Devolução --");

            Emprestimo[] emprestimos = repositorio.Listar();

            bool temEmprestimoAberto = false;

            for (int i = 0; i < repositorio.contador; i++)
            {
                Emprestimo e = emprestimos[i];

                if (e.Status == "Aberto")
                {
                    temEmprestimoAberto = true;
                    Console.WriteLine($"ID: {e.Id} | Amigo: {e.Amigo.Nome} | Revista: {e.Revista.Nome} | Devolução até: {e.DataDevolucao:dd/MM/yyyy}");
                }
            }

            if (!temEmprestimoAberto)
            {
                Console.WriteLine("Nenhum empréstimo em aberto para devolver.");
                Console.ReadKey();
                return;
            }

            Console.Write("Digite o ID do empréstimo a ser devolvido: ");
            int idEmprestimo = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < repositorio.contador; i++)
            {
                Emprestimo e = emprestimos[i];

                if (e.Id == idEmprestimo && e.Status == "Aberto")
                {
                    e.Status = "Concluído";
                    Console.WriteLine("Devolução registrada com sucesso!");
                    Console.ReadKey();
                    return;
                }
            }

            Console.WriteLine("Empréstimo não encontrado ou já devolvido.");
            Console.ReadKey();
        }
    }
}
