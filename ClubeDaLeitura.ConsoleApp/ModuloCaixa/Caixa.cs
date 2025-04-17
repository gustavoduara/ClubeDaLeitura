using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class Caixa
    {
        public int Id { get; set; }              // ID único da caixa
        public string Etiqueta { get; set; }     // Etiqueta única da caixa (máximo 50 caracteres)
        public string Cor { get; set; }          // Cor associada à caixa (pode ser hexadecimal ou nome)
        public int DiasEmprestimo { get; set; }  // Dias de empréstimo definidos para a caixa

        // Lista de revistas associadas à caixa
        public List<Revista> Revistas { get; set; }

        // Construtor
        public Caixa(int id, string etiqueta, string cor, int diasEmprestimo)
        {
            Id = id;
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = diasEmprestimo;
            Revistas = new List<Revista>();  // Inicializa a lista de revistas
        }

        // Método para verificar se a caixa é válida (exemplo de validações simples)
        public bool ValidarCaixa()
        {
            // Verificação de caixa válida (etiqueta não pode ser nula ou vazia, dias de empréstimo > 0)
            if (string.IsNullOrEmpty(Etiqueta) || DiasEmprestimo <= 0)
            {
                return false;
            }
            return true;
        }

        // Método para adicionar uma revista à caixa
        public void AdicionarRevista(Revista revista)
        {
            if (revista != null)
            {
                Revistas.Add(revista);
            }
        }

        // Método para remover uma revista da caixa
        public void RemoverRevista(Revista revista)
        {
            if (revista != null)
            {
                Revistas.Remove(revista);
            }
        }
    }

}
