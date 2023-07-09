using TestesDaDonaMariana.Dominio.Compartilhado;
using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;

namespace TestesDaDonaMariana.Dominio.ModuloTeste
{
    public class Teste : EntidadeBase<Teste>
    {
        public string titulo { get; set; }
        public Disciplina disciplina { get; set; }
        public Materia materia { get; set; }
        public int numQuestoes { get; set; }
        public DateTime dataCriacao { get; set; }
        public Teste()
        {
            
        }
        public Teste(int id, string titulo, Disciplina disciplina, Materia materia, int numQuestoes)
        {
            this.id = id;
            this.titulo = titulo;
            this.disciplina = disciplina;
            this.materia = materia;
            this.numQuestoes = numQuestoes;
            dataCriacao = DateTime.Now;
        }

        public override void AtualizarInformacoes(Teste registroAtualizado)
        {
            disciplina = registroAtualizado.disciplina;
            materia = registroAtualizado.materia;

        }

        public override string Validar()
        {
            Validador valida = new();

            if (valida.ValidaString(titulo))
                return $"Você deve escrever um título para seu teste!";

            if (titulo.Length <= 3)
                return $"Seu título deve conter ao menoss 4 caracteres!";

            if (disciplina == null)
                return $"Você deve selecionar uma disciplina!";

            if (materia == null)
                return $"Você deve selecionar uma matéria!";

            if (numQuestoes <= 0)
                return $"O número de questões deve ser maior que zero!";

            return "";
        }
    }
}
