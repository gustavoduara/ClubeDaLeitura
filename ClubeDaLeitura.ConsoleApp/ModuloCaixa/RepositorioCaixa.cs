using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
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
}
