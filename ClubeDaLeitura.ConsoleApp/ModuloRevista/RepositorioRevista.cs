
public class RepositorioRevista
{
    public Revista[] revistas = new Revista[100];
    public int contador = 0;

    public void Inserir(Revista novaRevista)
    {
        revistas[contador] = novaRevista;
        contador++;
    }

    public Revista[] Listar()
    {
        return revistas;
    }

    public Revista SelecionarPorId(int id)
    {
        for (int i = 0; i < contador; i++)
        {
            if (revistas[i] != null && revistas[i].Id == id)
                return revistas[i];
        }

        return null;
    }

    public bool Excluir(int id)
    {
        for (int i = 0; i < contador; i++)
        {
            if (revistas[i] != null && revistas[i].Id == id)
            {
                revistas[i] = null;
                return true;
            }
        }

        return false;
    }
}

