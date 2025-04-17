using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class Revista
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public int NumeroEdicao { get; set; }
    public int Ano { get; set; }
    public Caixa Caixa { get; set; }
    public string Status { get; set; }

    public Revista(int id, string titulo, int numeroEdicao, int ano, Caixa caixa)
    {
        Id = id;
        Titulo = titulo;
        NumeroEdicao = numeroEdicao;
        Ano = ano;
        Caixa = caixa;
        Status = "Disponível";
    }
}