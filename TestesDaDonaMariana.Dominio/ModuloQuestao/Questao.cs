using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;

namespace TestesDaDonaMariana.Dominio.ModuloQuestao
{
    public class Questao : EntidadeBase<Questao>
    {
        public List<Alternativa> alternativas { get; set; } 
        public Materia materia { get; set; }    
        public string enunciado { get; set; }    
        public string gabarito { get; set; }

        public Questao()
        {

        }

        public Questao(int id, Materia materia, string enunciado, string gabarito)
        {
            this.id = id;
            this.materia = materia;
            this.enunciado = enunciado;
            this.gabarito = gabarito;
            alternativas = new();
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
            throw new NotImplementedException();
        }
    }
}