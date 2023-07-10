using TestesDaDonaMariana.Dominio.Compartilhado;
using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.Dominio.ModuloTeste
{
    public class Teste : EntidadeBase<Teste>
    {
        public string titulo { get; set; }
        public int numQuestoes { get; set; }
        public DateTime dataCriacao { get; set; }
        public Disciplina disciplina { get; set; }
        public List<Materia> materias { get; set; }
        public List<Questao> questoes { get; set; } = new();

        public Teste()
        {
            
        }

        public Teste(int id, string titulo, Disciplina disciplina, List<Materia> materias, int numQuestoes)
        {
            this.id = id;
            this.titulo = titulo;
            this.disciplina = disciplina;
            this.materias = materias;
            this.numQuestoes = numQuestoes;
            dataCriacao = DateTime.Now;
        }

        public override void AtualizarInformacoes(Teste registroAtualizado)
        {
            disciplina = registroAtualizado.disciplina;
            materias = registroAtualizado.materias;

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

            if (materias.Count == 0)
                return $"Você deve selecionar uma matéria!";

            if (numQuestoes <= 0)
                return $"O quantidade de questões deve ser maior que zero!";

            if (numQuestoes > 20)
                return $"O quantidade máxima de questões, por teste, são 20!";

            if (materias.Count > 1)
            {
                int? qtdQuestoes = 0;

                foreach (Materia m in materias)
                {
                    qtdQuestoes = qtdQuestoes + m.qtdQuestoesMateria;
                }
                if (qtdQuestoes < numQuestoes)
                    return $"Você tem apenas {qtdQuestoes} questões dessa matéria no banco!";
                else
                    return "";
            }

            Materia materia = new();

            if (materias.Count == 1)
                materia = materias.FirstOrDefault(x => x == materias[0]);

            if (materia.questoes.Count < numQuestoes)
                return $"Você tem apenas {materia.questoes.Count} questões dessa matéria no banco!";

            return "";
        }
    }
}
