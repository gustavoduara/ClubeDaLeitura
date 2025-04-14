
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
}
