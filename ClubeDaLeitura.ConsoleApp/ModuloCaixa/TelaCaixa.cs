﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class TelaCaixa
    {
        private RepositorioCaixa repositorioCaixa;

        public TelaCaixa(RepositorioCaixa repositorioCaixa)
        {
            this.repositorioCaixa = repositorioCaixa;
        }

        public void MostrarMenu()
        {
            char opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("== Clube da Leitura - Caixas ==");
                Console.WriteLine("1 - Inserir nova caixa");
                Console.WriteLine("2 - Listar caixas");
                Console.WriteLine("3 - Editar caixa");
                Console.WriteLine("4 - Excluir caixa");
                Console.WriteLine("S - Sair");
                Console.Write("Opção: ");
                opcao = char.ToUpper(Console.ReadKey().KeyChar);

                if (opcao == '1')
                    InserirCaixa();
                else if (opcao == '2')
                    ListarCaixas();
                else if (opcao == '3')
                    EditarCaixas();
                else if (opcao == '4')
                    ExcluirCaixa();

            } while (opcao != 'S');
        }

        public void InserirCaixa()
        {
            Console.Clear();
            Console.WriteLine("-- Inserir nova caixa --");

            Console.Write("Etiqueta: ");
            string etiqueta = Console.ReadLine();

            Console.Write("Cor: ");
            string cor = Console.ReadLine();

            Console.Write("Dias de empréstimo: ");
            int diasEmprestimo = Convert.ToInt32(Console.ReadLine());

            int id = repositorioCaixa.contador + 1;

            Caixa nova = new Caixa(id, etiqueta, cor, diasEmprestimo);

            repositorioCaixa.Inserir(nova);

            Console.WriteLine("Caixa cadastrada com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void ListarCaixas()
        {
            Console.Clear();
            Console.WriteLine("-- Lista de caixas --");

            Caixa[] lista = repositorioCaixa.Listar();

            for (int i = 0; i < repositorioCaixa.contador; i++)
            {
                Caixa c = lista[i];
                Console.WriteLine($"ID: {c.Id} | Etiqueta: {c.Etiqueta} | Cor: {c.Cor} | Dias de Empréstimo: {c.DiasEmprestimo}");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void EditarCaixas()
        {
            Console.Clear();
            Console.WriteLine("-- Editar caixa --");

            ListarCaixas();

            Console.Write("Digite o ID da caixa que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Caixa caixaExistente = repositorioCaixa.caixas.FirstOrDefault(c => c.Id == id);

            if (caixaExistente == null)
            {
                Console.WriteLine("Caixa não encontrada!");
                Console.ReadKey();
                return;
            }

            Console.Write("Nova etiqueta: ");
            caixaExistente.Etiqueta = Console.ReadLine();

            Console.Write("Nova cor: ");
            caixaExistente.Cor = Console.ReadLine();

            Console.Write("Novo número de dias de empréstimo: ");
            caixaExistente.DiasEmprestimo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Caixa editada com sucesso!");
            Console.ReadKey();
        }

        public void ExcluirCaixa()
        {
            Console.Clear();
            Console.WriteLine("-- Excluir Caixa --");

            ListarCaixas();

            Console.Write("Digite o ID da caixa que deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = repositorioCaixa.Excluir(id);

            if (conseguiuExcluir)
                Console.WriteLine("Caixa excluída com sucesso!");
            else
                Console.WriteLine("Não foi possível excluir a caixa. Verifique se a caixa está sendo utilizada.");

            Console.ReadKey();
        }
    }
}

