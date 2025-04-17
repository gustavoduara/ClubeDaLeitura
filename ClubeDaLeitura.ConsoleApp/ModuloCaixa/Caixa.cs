using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class Caixa
    {
        public int Id { get; set; }              
        public string Etiqueta { get; set; }    
        public string Cor { get; set; }          
        public int DiasEmprestimo { get; set; }  

        
        public List<Revista> Revistas { get; set; }

       
        public Caixa(int id, string etiqueta, string cor, int diasEmprestimo)
        {
            Id = id;
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = diasEmprestimo;
            Revistas = new List<Revista>(); 
        }

       
        public bool ValidarCaixa()
        {
            
            if (string.IsNullOrEmpty(Etiqueta) || DiasEmprestimo <= 0)
            {
                return false;
            }
            return true;
        }

        
        public void AdicionarRevista(Revista revista)
        {
            if (revista != null)
            {
                Revistas.Add(revista);
            }
        }

       
        public void RemoverRevista(Revista revista)
        {
            if (revista != null)
            {
                Revistas.Remove(revista);
            }
        }
    }

}
