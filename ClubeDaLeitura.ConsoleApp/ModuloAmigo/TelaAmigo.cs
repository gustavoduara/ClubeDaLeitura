using ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class TelaAmigo
{
    private RepositorioAmigo repositorio = new RepositorioAmigo();

    public void MostrarMenu()
    {
        char opcao;

        do
        {
            Console.Clear();
            Console.WriteLine("== Clube da Leitura - Amigos ==");
            Console.WriteLine("1 - Inserir novo amigo");
            Console.WriteLine("2 - Listar amigos");
            Console.WriteLine("S - Sair");
            Console.Write("Opção: ");
            opcao = char.ToUpper(Console.ReadKey().KeyChar);

            if (opcao == '1')
                InserirAmigo();
            else if (opcao == '2')
                ListarAmigos();

        } while (opcao != 'S');
    }

    public void InserirAmigo()
    {
        Console.Clear();
        Console.WriteLine("-- Inserir novo amigo --");

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Responsável: ");
        string responsavel = Console.ReadLine();

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();

        int id = repositorio.contador + 1;

        Amigo novo = new Amigo(id, nome, responsavel, telefone);

        repositorio.Inserir(novo);

        Console.WriteLine("Amigo cadastrado com sucesso!");
        Console.ReadKey();
    }

    public void ListarAmigos()
    {
        Console.Clear();
        Console.WriteLine("-- Lista de amigos --");

        Amigo[] lista = repositorio.Listar();

        for (int i = 0; i < repositorio.contador; i++)
        {
            Amigo a = lista[i];
            Console.WriteLine($"ID: {a.Id} | Nome: {a.Nome} | Tel: {a.Telefone} | Resp: {a.Responsavel}");
        }

        Console.ReadLine();
    }
}