using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class TelaRevista
{
    private RepositorioRevista repositorioRevista;
    private RepositorioCaixa repositorioCaixa;

    public TelaRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa)
    {
        // Atribuindo corretamente os valores recebidos ao campo de instância
        this.repositorioRevista = repositorioRevista;
        this.repositorioCaixa = repositorioCaixa;
    }
    public void MostrarMenu()
    {
        char opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("== Clube da Leitura - Revistas ==");
            Console.WriteLine("1 - Cadastrar nova revista");
            Console.WriteLine("2 - Visualizar revistas");
            Console.WriteLine("3 - Editar revista");
            Console.WriteLine("4 - Excluir revista");
            Console.WriteLine("S - Voltar");
            Console.Write("Opção: ");
            opcao = char.ToUpper(Console.ReadKey().KeyChar);

            if (opcao == '1') CadastrarRevista();
            else if (opcao == '2') VisualizarRevistas();
            else if (opcao == '3') EditarRevista();
            else if (opcao == '4') ExcluirRevista();

        } while (opcao != 'S');
    }

    public void CadastrarRevista()
    {
        Console.Clear();
        Console.WriteLine("-- Cadastro de Revista --");

        Console.Write("Título: ");
        string titulo = Console.ReadLine();

        Console.Write("Número da Edição: ");
        int numeroEdicao = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ano de Publicação: ");
        int ano = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Selecione a Caixa:");
        for (int i = 0; i < repositorioCaixa.contador; i++)
        {
            Caixa c = repositorioCaixa.caixas[i];
            Console.WriteLine($"ID: {c.Id} | Etiqueta: {c.Etiqueta}");
        }

        int idCaixa = Convert.ToInt32(Console.ReadLine());
        Caixa caixaSelecionada = repositorioCaixa.BuscarPorId(idCaixa);

        if (caixaSelecionada == null)
        {
            Console.WriteLine("Caixa não encontrada!");
            Console.ReadKey();
            return;
        }

        int id = repositorioRevista.contador + 1;

        Revista novaRevista = new Revista(id, titulo, numeroEdicao, ano, caixaSelecionada);

        repositorioRevista.Inserir(novaRevista);

        Console.WriteLine("Revista cadastrada com sucesso!");
        Console.ReadKey();
    }

    public void VisualizarRevistas()
    {
        Console.Clear();
        Console.WriteLine("-- Lista de Revistas --");

        Revista[] revistas = repositorioRevista.Listar();

        for (int i = 0; i < repositorioRevista.contador; i++)
        {
            Revista r = revistas[i];

            Console.WriteLine($"ID: {r.Id} | Título: {r.Titulo} | Edição: {r.NumeroEdicao} | Ano: {r.Ano} | Caixa: {r.Caixa.Etiqueta} | Status: {r.Status}");
        }

        Console.ReadKey();
    }

    public void EditarRevista()
    {
        Console.Clear();
        Console.WriteLine("-- Editar Revista --");

        VisualizarRevistas();

        Console.Write("Digite o ID da revista que deseja editar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Revista revista = repositorioRevista.SelecionarPorId(id);

        if (revista == null)
        {
            Console.WriteLine("Revista não encontrada!");
            Console.ReadKey();
            return;
        }

        Console.Write("Novo título: ");
        revista.Titulo = Console.ReadLine();

        Console.Write("Novo número da edição: ");
        revista.NumeroEdicao = Convert.ToInt32(Console.ReadLine());

        Console.Write("Novo ano de publicação: ");
        revista.Ano = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Selecione nova Caixa:");
        for (int i = 0; i < repositorioCaixa.contador; i++)
        {
            Caixa c = repositorioCaixa.caixas[i];
            Console.WriteLine($"ID: {c.Id} | Etiqueta: {c.Etiqueta}");
        }

        int idCaixa = Convert.ToInt32(Console.ReadLine());
        Caixa novaCaixa = repositorioCaixa.BuscarPorId(idCaixa);

        if (novaCaixa != null)
            revista.Caixa = novaCaixa;

        Console.WriteLine("Revista editada com sucesso!");
        Console.ReadKey();
    }

    public void ExcluirRevista()
    {
        Console.Clear();
        Console.WriteLine("-- Excluir Revista --");

        VisualizarRevistas();

        Console.Write("Digite o ID da revista que deseja excluir: ");
        int id = Convert.ToInt32(Console.ReadLine());

        bool removido = repositorioRevista.Excluir(id);

        if (removido)
            Console.WriteLine("Revista excluída com sucesso!");
        else
            Console.WriteLine("Não foi possível excluir (talvez já esteja emprestada).");

        Console.ReadKey();
    }
}