using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloTeste;

namespace TestesDaDonaMariana.Dominio.ModuloQuestao
{
    public class Questao : EntidadeBase<Questao>
    {
        public List<Alternativa> alternativas { get; set; } 
        public Disciplina disciplina { get; set; }    
        public Materia materia { get; set; }
        public string enunciado { get; set; }    
        public string gabarito { get; set; }

        public Questao()
        {

        }

        public Questao(int id, Disciplina disciplina, Materia materia, string enunciado, string gabarito)
        {
            this.id = id;
            this.disciplina = disciplina;
            this.materia = materia;
            this.enunciado = enunciado;
            this.gabarito = gabarito;
        }

        public override void AtualizarInformacoes(Questao registroAtualizado)
        {
            materia = registroAtualizado.materia;
            enunciado = registroAtualizado.enunciado;
            gabarito = registroAtualizado.gabarito;
            alternativas = registroAtualizado.alternativas;
        }

        public override string Validar()
        {
            Validador valida = new();

            if (valida.ValidaString(enunciado))
                return $"Você deve escrever um enunciado para sua questão!";

            if (enunciado.Length < 14)
                return $"O enunciado deve conter ao menos 15 caracteres!";

            if (disciplina == null)
                return $"Você deve selecionar uma disciplina!"; 
            
            if (materia == null)
                return $"Você deve selecionar uma matéria!";

            return "";
        }
    }
}