using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class RepositorioCaixa
{
    public Caixa[] caixas = new Caixa[100];
    public int contador = 0;

    public void Inserir(Caixa novaCaixa)
    {
        caixas[contador] = novaCaixa;
        contador++;
    }

    public Caixa[] Listar()
    {
        return caixas;
    }
}
