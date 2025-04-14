using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    public class Amigo
    {
        public int Id;
        public string Name;
        public string Responsavel;
        public string Telefone;

        public Amigo(int Id, string nome, string responsavel, string telefone) 
        {
            Id = Id;
            Name = nome;
            Responsavel = responsavel;
            Telefone = telefone;
        }


    }
}
