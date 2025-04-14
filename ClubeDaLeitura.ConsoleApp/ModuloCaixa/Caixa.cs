using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class Caixa
    {
        public int Id;
        public string Etiqueta;
        public string Cor;
        public int Numero;

        public Caixa(int id, string etiqueta, string cor, int numero)
        {
            Id = id;
            Etiqueta = etiqueta;
            Cor = cor;
            Numero = numero;
        }
    }
}
