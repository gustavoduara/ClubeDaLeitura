using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class RepositorioCaixa
{
    public List<Caixa> caixas { get; private set; }
    public int contador { get; private set; }

    public RepositorioCaixa()
    {
        caixas = new List<Caixa>();
        contador = 0;
    }

    public void Inserir(Caixa caixa)
    {
        caixas.Add(caixa);
        contador++;
    }

    public Caixa BuscarPorId(int id)
    {
        return caixas.FirstOrDefault(c => c.Id == id);
    }

    public Caixa[] Listar()
    {
        return caixas.Take(contador).ToArray();
    }

    public bool Editar(int id, string etiqueta, string cor, int diasEmprestimo)
    {
        Caixa caixa = BuscarPorId(id);

        if (caixa != null)
        {
            caixa.Etiqueta = etiqueta;
            caixa.Cor = cor;
            caixa.DiasEmprestimo = diasEmprestimo;
            return true;
        }

        return false;
    }

    public bool Excluir(int id)
    {
        Caixa caixa = BuscarPorId(id);

        if (caixa != null)
        {
            if (caixa.Revistas.Count > 0)
            {
                return false;
            }

            caixas.Remove(caixa);
            contador--;
            return true;
        }

        return false;
    }
}