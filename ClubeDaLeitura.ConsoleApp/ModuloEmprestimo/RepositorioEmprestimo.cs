using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class RepositorioEmprestimo
    {
        public Emprestimo[] emprestimos = new Emprestimo[100];
        public int contador = 0;

        public void Inserir(Emprestimo emprestimo)
        {
            emprestimos[contador] = emprestimo;
            contador++;
        }

        public Emprestimo[] Listar()
        {
            return emprestimos;
        }

        public bool AmigoTemEmprestimoAberto(Amigo amigo)
        {
            for (int i = 0; i < contador; i++)
            {
                if (emprestimos[i].Amigo == amigo && emprestimos[i].Status == "Aberto")
                    return true;
            }

            return false;
        }

        public Emprestimo BuscarPorId(int id)
        {
            for (int i = 0; i < contador; i++)
            {
                if (emprestimos[i].Id == id)
                    return emprestimos[i];
            }

            return null;
        }
    }
}
