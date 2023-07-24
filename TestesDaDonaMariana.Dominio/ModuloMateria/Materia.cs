﻿using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.Dominio.ModuloMateria
{
    [Serializable]
    public class Materia : EntidadeBase<Materia>
    {
        public string serie { get; set; }
        public string titulo { get; set; }
        public Disciplina disciplina { get; set; }
        public List<Questao>? questoes { get; set; } = new();
        public int? qtdQuestoesMateria { get { return questoes?.Count(); } }

        public Materia()
        {

        }

        public Materia(int id)
        {
            this.id = id;
        }

        public Materia(int id, string titulo, Disciplina disciplina, string serie)
        {
            this.id = id;
            this.titulo = titulo;
            this.disciplina = disciplina;
            this.serie = serie;
        }

        public Materia(int id, string titulo, Disciplina disciplina, string serie, List<Questao>? questoes)
        {
            this.id = id;
            this.titulo = titulo;
            this.disciplina = disciplina;
            this.serie = serie;
            this.questoes = questoes;
        }

        public override void AtualizarInformacoes(Materia registroAtualizado)
        {
            titulo = registroAtualizado.titulo;
            disciplina = registroAtualizado.disciplina;
            serie = registroAtualizado.serie;
        }

        public override string Validar()
        {
            Validador valida = new();

            if (valida.ValidaString(titulo))
                return $"Você deve escrever um título!";

            if (titulo.Length <= 2)
                return $"O título da matéria deve conter no mínimo 3 caracteres!";

            if (disciplina == null)
                return $"Você deve selecionar uma disciplina!";

            if (serie == null)
                return $"Você deve selecionar uma série!";

            return "";
        }

        public override string ToString()
        {
            return titulo;
        }
    }
}
