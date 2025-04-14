
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
    }
}
