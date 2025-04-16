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

    public Caixa BuscarPorId(int id)
    {
        for (int i = 0; i < contador; i++)
        {
            if (caixas[i].Id == id)
                return caixas[i];
        }
        return null;
    }

    public bool Excluir(int id)
    {
        for (int i = 0; i < contador; i++)
        {
            if (caixas[i].Id == id)
            {
                for (int j = i; j < contador - 1; j++)
                {
                    caixas[j] = caixas[j + 1];
                }

                caixas[contador - 1] = null;
                contador--;

                return true;
            }
        }

        return false;
    }
}