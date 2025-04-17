using ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class TelaAmigo
{
    private RepositorioAmigo repositorioAmigo;

    public TelaAmigo(RepositorioAmigo repositorioAmigo)
    {
        this.repositorioAmigo = repositorioAmigo;
    }

    public void MostrarMenu()
    {
        char opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("== Clube da Leitura - Amigos ==");
            Console.WriteLine("1 - Cadastrar novo amigo");
            Console.WriteLine("2 - Listar amigos");
            Console.WriteLine("3 - Editar amigo");
            Console.WriteLine("4 - Excluir amigo");
            Console.WriteLine("S - Voltar");
            Console.Write("Opção: ");
            opcao = char.ToUpper(Console.ReadKey().KeyChar);

            if (opcao == '1')
                CadastrarAmigo();
            else if (opcao == '2')
                ListarAmigos();
            else if (opcao == '3')
                EditarAmigo();
            else if (opcao == '4')
                ExcluirAmigo();

        } while (opcao != 'S');
    }

    public void CadastrarAmigo()
    {
        Console.Clear();
        Console.WriteLine("-- Cadastro de Amigo --");

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Responsável: ");
        string responsavel = Console.ReadLine();

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();

        int id = repositorioAmigo.contador + 1;

        Amigo novoAmigo = new Amigo(id, nome, responsavel, telefone);

        repositorioAmigo.Inserir(novoAmigo);

        Console.WriteLine("Amigo cadastrado com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    public void ListarAmigos()
    {
        Console.Clear();
        Console.WriteLine("-- Lista de Amigos --");

        Amigo[] amigos = repositorioAmigo.Listar();

        for (int i = 0; i < repositorioAmigo.contador; i++)
        {
            Amigo amigo = amigos[i];
            Console.WriteLine($"ID: {amigo.Id} | Nome: {amigo.Nome} | Responsável: {amigo.Responsavel} | Telefone: {amigo.Telefone}");
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    public void EditarAmigo()
    {
        Console.Clear();
        Console.WriteLine("-- Editar Amigo --");

        ListarAmigos();

        Console.Write("Digite o ID do amigo que deseja editar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Amigo amigoExistente = repositorioAmigo.SelecionarPorId(id);

        if (amigoExistente == null)
        {
            Console.WriteLine("Amigo não encontrado!");
            Console.ReadKey();
            return;
        }

        Console.Write("Novo nome: ");
        amigoExistente.Nome = Console.ReadLine();

        Console.Write("Novo responsável: ");
        amigoExistente.Responsavel = Console.ReadLine();

        Console.Write("Novo telefone: ");
        amigoExistente.Telefone = Console.ReadLine();

        Console.WriteLine("Amigo editado com sucesso!");
        Console.ReadKey();
    }

    public void ExcluirAmigo()
    {
        Console.Clear();
        Console.WriteLine("-- Excluir Amigo --");

        ListarAmigos();

        Console.Write("Digite o ID do amigo que deseja excluir: ");
        int id = Convert.ToInt32(Console.ReadLine());

        bool removido = repositorioAmigo.Excluir(id);

        if (removido)
            Console.WriteLine("Amigo excluído com sucesso!");
        else
            Console.WriteLine("Não foi possível excluir o amigo.");

        Console.ReadKey();
    }
}