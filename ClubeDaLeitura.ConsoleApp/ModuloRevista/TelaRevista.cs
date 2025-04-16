public class TelaRevista
{
    public RepositorioRevista repositorio = new RepositorioRevista();

    public void MostrarMenu()
    {
        char opcao;

        do
        {
            Console.Clear();
            Console.WriteLine("== Clube da Leitura - Revistas ==");
            Console.WriteLine("1 - Inserir nova revista");
            Console.WriteLine("2 - Listar revistas");
            Console.WriteLine("3 - Editar revista");
            Console.WriteLine("4 - Excluir revista");
            Console.WriteLine("S - Sair");
            Console.Write("Opção: ");
            opcao = char.ToUpper(Console.ReadKey().KeyChar);

            if (opcao == '1')
                InserirRevista();
            else if (opcao == '2')
                ListarRevistas();
            else if (opcao == '3')
                EditarRevista();
            else if (opcao == '4')
                ExcluirRevista();

        } while (opcao != 'S');
    }

    public void InserirRevista()
    {
        Console.Clear();
        Console.WriteLine("-- Inserir nova revista --");

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Editora: ");
        string editora = Console.ReadLine();

        Console.Write("Ano: ");
        int ano = Convert.ToInt32(Console.ReadLine());

        int id = repositorio.contador + 1;

        Revista nova = new Revista(id, nome, editora, ano);

        repositorio.Inserir(nova);

        Console.WriteLine("Revista cadastrada com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    public void ListarRevistas()
    {
        Console.Clear();
        Console.WriteLine("-- Lista de revistas --");

        Revista[] lista = repositorio.Listar();

        for (int i = 0; i < repositorio.contador; i++)
        {
            Revista r = lista[i];
            Console.WriteLine($"ID: {r.Id} | Nome: {r.Nome} | Editora: {r.Editora} | Ano: {r.Ano}");
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    public void EditarRevista()
    {
        Console.Clear();
        Console.WriteLine("-- Editar Revista --");

        ListarRevistas();

        Console.Write("Digite o ID da revista que deseja editar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Revista revista = repositorio.SelecionarPorId(id);

        if (revista == null)
        {
            Console.WriteLine("Revista não encontrada!");
            Console.ReadKey();
            return;
        }

        Console.Write("Novo nome: ");
        string novoNome = Console.ReadLine();

        Console.Write("Nova editora: ");
        string novaEditora = Console.ReadLine();

        Console.Write("Novo ano: ");
        int novoAno = Convert.ToInt32(Console.ReadLine());

        revista.Nome = novoNome;
        revista.Editora = novaEditora;
        revista.Ano = novoAno;

        Console.WriteLine("Revista editada com sucesso!");
        Console.ReadKey();
    }

    public void ExcluirRevista()
    {
        Console.Clear();
        Console.WriteLine("-- Excluir Revista --");

        ListarRevistas();

        Console.Write("Digite o ID da revista que deseja excluir: ");
        int id = Convert.ToInt32(Console.ReadLine());

        bool sucesso = repositorio.Excluir(id);

        if (sucesso)
            Console.WriteLine("Revista excluída com sucesso!");
        else
            Console.WriteLine("Revista não encontrada.");

        Console.ReadKey();
    }
}