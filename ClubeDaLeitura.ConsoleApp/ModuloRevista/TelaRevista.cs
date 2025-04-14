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
            Console.WriteLine("S - Sair");
            Console.Write("Opção: ");
            opcao = char.ToUpper(Console.ReadKey().KeyChar);

            if (opcao == '1')
                InserirRevista();
            else if (opcao == '2')
                ListarRevistas();

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
}