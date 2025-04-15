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
            Console.WriteLine("3 - Excluir amigo");
            Console.WriteLine("4 - Editar amigo");
            Console.WriteLine("S - Sair");
            Console.Write("Opção: ");
            opcao = char.ToUpper(Console.ReadKey().KeyChar);

            if (opcao == '1')
                InserirAmigo();
            else if (opcao == '2')
                ListarAmigos();
            else if (opcao == '3')
                EditarAmigo();
            else if (opcao == '4')
                ExcluirAmigo();

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

    public void ExcluirAmigo()
    {
        Console.Clear();
        Console.WriteLine("-- Excluir amigo --");
        ListarAmigos();

        Console.Write("Digite o ID do amigo que deseja excluir: ");
        int id = Convert.ToInt32(Console.ReadLine());

        repositorio.Excluir(id);

        Console.WriteLine("Amigo excluído com sucesso!");
        Console.ReadKey();
    }

    public void EditarAmigo()
    {
        Console.Clear();
        Console.WriteLine("-- Editar amigo --");

        ListarAmigos();

        Console.Write("Digite o ID do amigo que deseja editar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Novo nome: ");
        string nome = Console.ReadLine();

        Console.Write("Novo telefone0: ");
        string telefone = Console.ReadLine();

        Console.Write("Novo responsável: ");
        string responsavel = Console.ReadLine();

        Amigo amigoEditado = new Amigo(id, nome, responsavel, telefone);

        repositorio.Editar(id, amigoEditado);

        Console.WriteLine("Amigo editado com sucesso!");
        Console.ReadKey();
    }
}