using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class Emprestimo
    {
        public int Id;
        public Amigo Amigo;
        public Revista Revista;
        public DateTime DataEmprestimo;
        public DateTime DataDevolucao;
        public string Status;

        public Emprestimo(int id, Amigo amigo, Revista revista, DateTime dataEmprestimo, DateTime dataDevolucao)
        {
            Id = id;
            Amigo = amigo;
            Revista = revista;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
            Status = "Aberto";
        }
    }
}
