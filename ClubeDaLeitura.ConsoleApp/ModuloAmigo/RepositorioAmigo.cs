
namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class RepositorioAmigo
    {
        public Amigo[] amigos;
        public int contador;

        public RepositorioAmigo()
        {
            amigos = new Amigo[10];  // Tamanho fixo para exemplo
            contador = 0;
        }

        public void Inserir(Amigo amigo)
        {
            amigos[contador] = amigo;
            contador++;
        }

        public Amigo[] Listar()
        {
            Amigo[] amigosListados = new Amigo[contador];
            Array.Copy(amigos, amigosListados, contador);
            return amigosListados;
        }

        // Método para buscar um amigo pelo ID
        public Amigo SelecionarPorId(int id)
        {
            for (int i = 0; i < contador; i++)
            {
                if (amigos[i].Id == id)
                    return amigos[i];
            }
            return null;  // Retorna null se não encontrar o amigo com o ID especificado
        }

        public bool Excluir(int id)
        {
            for (int i = 0; i < contador; i++)
            {
                if (amigos[i].Id == id)
                {
                    // Move os elementos à esquerda para preencher o vazio
                    for (int j = i; j < contador - 1; j++)
                    {
                        amigos[j] = amigos[j + 1];
                    }
                    amigos[contador - 1] = null;
                    contador--;
                    return true;
                }
            }
            return false;
        }
    }
}
