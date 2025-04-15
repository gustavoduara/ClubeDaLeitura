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

        public void Inserir(Emprestimo novo)
        {
            emprestimos[contador] = novo;
            contador++;
        }

        public Emprestimo[] Listar()
        {
            return emprestimos;
        }
    }
}
