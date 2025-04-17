﻿
    public class Amigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Responsavel { get; set; }
        public string Telefone { get; set; }
        public Amigo(int id, string nome, string responsavel, string telefone)
        {
            Id = id;
            Nome = nome;
            Responsavel = responsavel;
            Telefone = telefone;
        }

        public string Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome) || Nome.Length < 3)
                return "O campo 'Nome' é obrigatório e precisa conter ao menos 3 caracteres.";

            if (string.IsNullOrWhiteSpace(Responsavel))
                return "O campo 'Responsável' é obrigatório.";

            if (string.IsNullOrWhiteSpace(Telefone))
                return "O campo 'Telefone' é obrigatório.";

            return "";
        }
    }

