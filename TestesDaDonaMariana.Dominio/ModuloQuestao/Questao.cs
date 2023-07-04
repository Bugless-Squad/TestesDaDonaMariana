using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;

namespace TestesDaDonaMariana.Dominio.ModuloQuestao
{
    public class Questao : EntidadeBase<Questao>
    {
        public List<Alternativa> alternativas { get; set; }
        public Disciplina diciplina { get; set; }    
        public Materia materia { get; set; }    
        public string enunciado { get; set; }    
        public string gabarito { get; set; }

        public Questao()
        {

        }

        public Questao(Disciplina diciplina, Materia materia, string enunciado, string gabarito)
        {
            this.diciplina = diciplina;
            this.materia = materia;
            this.enunciado = enunciado;
            this.gabarito = gabarito;
            this.alternativas = new();
        }

        public override void AtualizarInformacoes(Questao registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
