
namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class RepositorioAmigo
    {
        public Amigo[] amigos = new Amigo[100];
        public int contador = 0;

        public void Inserir(Amigo novoAmigo)
        {
            novoAmigo.Id = contador + 1;
            amigos[contador] = novoAmigo;
            contador++;
        }

        public Amigo[] Listar()
        {
            return amigos;
        }

        public void Excluir(int id)
        {
            for (int i = 0; i < contador; i++)
            {
                if (amigos[i].Id == id)
                {
                    // "Puxa" os próximos itens para frente
                    for (int j = i; j < contador - 1; j++)
                    {
                        amigos[j] = amigos[j + 1];
                    }

                    contador--;
                    break;
                }
            }
        }
    }
}
