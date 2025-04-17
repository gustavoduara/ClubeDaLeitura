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

        public Emprestimo(int id, Amigo amigo, Revista revista, DateTime dataEmprestimo)
        {
            Id = id;
            Amigo = amigo;
            Revista = revista;
            DataEmprestimo = dataEmprestimo;

            int diasEmprestimo = revista.Caixa.DiasEmprestimo;
            DataDevolucao = dataEmprestimo.AddDays(diasEmprestimo);

            Status = "Aberto";
        }

        public void Concluir()
        {
            Status = "Concluído";
        }

        public void VerificarAtraso()
        {
            if (Status == "Aberto" && DataDevolucao < DateTime.Today)
            {
                Status = "Atrasado";
            }
        }
    }
}
