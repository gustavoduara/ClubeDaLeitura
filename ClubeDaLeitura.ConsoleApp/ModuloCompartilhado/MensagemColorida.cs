using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloCompartilhado
{
    using System;

    namespace ClubeDaLeitura.Compartilhado
    {
        public static class MensagemColorida
        {
            public static void MostrarMensagem(string mensagem, ConsoleColor cor)
            {
                Console.ForegroundColor = cor;
                Console.WriteLine(mensagem);
                Console.ResetColor();
            }
        }
    }

}
