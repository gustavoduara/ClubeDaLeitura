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
        private RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();
        private RepositorioAmigo repositorioAmigo;
        private RepositorioRevista repositorioRevista;

        public TelaEmprestimo(RepositorioAmigo amigos, RepositorioRevista revistas)
        {
            repositorioAmigo = amigos;
            repositorioRevista = revistas;
        }

        public void MostrarMenu()
        {
            char opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("== Clube da Leitura - Empréstimos ==");
                Console.WriteLine("1 - Registrar empréstimo");
                Console.WriteLine("2 - Visualizar empréstimos");
                Console.WriteLine("3 - Registrar Devolução");
                Console.WriteLine("S - Voltar");
                Console.Write("Opção: ");
                opcao = char.ToUpper(Console.ReadKey().KeyChar);

                if (opcao == '1')
                    RegistrarEmprestimo();
                else if (opcao == '2')
                    VisualizarEmprestimos();
                else if (opcao == '3')
                    RegistrarDevolucao();

            } while (opcao != 'S');
        }

        public void RegistrarEmprestimo()
        {
            Console.Clear();
            Console.WriteLine("-- Novo Empréstimo --");

            Console.WriteLine("Selecione o ID do amigo:");
            for (int i = 0; i < repositorioAmigo.contador; i++)
            {
                Amigo a = repositorioAmigo.amigos[i];
                Console.WriteLine($"ID: {a.Id} | Nome: {a.Nome}");
            }

            int idAmigo = Convert.ToInt32(Console.ReadLine());
            Amigo amigoSelecionado = repositorioAmigo.SelecionarPorId(idAmigo);

            if (amigoSelecionado == null)
            {
                Console.WriteLine("Amigo não encontrado!");
                Console.ReadKey();
                return;
            }

            if (repositorioEmprestimo.AmigoTemEmprestimoAberto(amigoSelecionado))
            {
                Console.WriteLine("Este amigo já possui um empréstimo em aberto!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Selecione o ID da revista:");
            for (int i = 0; i < repositorioRevista.contador; i++)
            {
                Revista r = repositorioRevista.revistas[i];
                Console.WriteLine($"ID: {r.Id} | Revista: {r.Titulo} - Edição {r.NumeroEdicao} | Caixa: {r.Caixa.Etiqueta}");
            }

            int idRevista = Convert.ToInt32(Console.ReadLine());
            Revista revistaSelecionada = repositorioRevista.SelecionarPorId(idRevista);

            if (revistaSelecionada == null)
            {
                Console.WriteLine("Revista não encontrada!");
                Console.ReadKey();
                return;
            }

            int idEmprestimo = repositorioEmprestimo.contador + 1;
            DateTime dataEmprestimo = DateTime.Today;

            Emprestimo novo = new Emprestimo(idEmprestimo, amigoSelecionado, revistaSelecionada, dataEmprestimo);

            repositorioEmprestimo.Inserir(novo);

            Console.WriteLine("Empréstimo registrado com sucesso!");
            Console.ReadKey();
        }

        public void VisualizarEmprestimos()
        {
            Console.Clear();
            Console.WriteLine("-- Empréstimos --");

            Emprestimo[] lista = repositorioEmprestimo.Listar();

            for (int i = 0; i < repositorioEmprestimo.contador; i++)
            {
                Emprestimo e = lista[i];
                e.VerificarAtraso();

                
                if (e.Status == "Atrasado")
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (e.Status == "Concluído")
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine($"ID: {e.Id} | Amigo: {e.Amigo.Nome} | Revista: {e.Revista.Titulo} - Edição {e.Revista.NumeroEdicao} | Empréstimo: {e.DataEmprestimo.ToShortDateString()} | Devolução: {e.DataDevolucao.ToShortDateString()} | Status: {e.Status}");

                Console.ResetColor();
            }

            Console.ReadKey();
        }

        public void RegistrarDevolucao()
        {
            Console.Clear();
            Console.WriteLine("-- Registrar Devolução --");

            Console.Write("Digite o ID do empréstimo que deseja devolver: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Emprestimo emprestimo = repositorioEmprestimo.BuscarPorId(id);

            if (emprestimo == null)
            {
                Console.WriteLine("Empréstimo não encontrado!");
                Console.ReadKey();
                return;
            }

            if (emprestimo.Status == "Concluído")
            {
                Console.WriteLine("Este empréstimo já foi concluído.");
                Console.ReadKey();
                return;
            }

            emprestimo.Status = "Concluído";

            Console.WriteLine("Devolução registrada com sucesso!");
            Console.ReadKey();
        }
    }

}
