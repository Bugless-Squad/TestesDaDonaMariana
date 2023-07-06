using System.Drawing;
using TestesDaDonaMariana.Dominio.Compartilhado;
using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public string titulo { get; set; }
        public Disciplina disciplina { get; set; }
        public OpcoesSerieEnum serie { get; set; }

        public Questao questao { get; set; }  //qtdCadastrada
        public Materia()
        {
        }

        public Materia( int id, string titulo,Disciplina disciplina, int serie)
        {
            this.id = id;
            this.titulo = titulo;
            this.disciplina = disciplina;
            this.serie = (OpcoesSerieEnum)serie;
        }

        public override void AtualizarInformacoes(Materia registroAtualizado)
        {
            this.titulo = registroAtualizado.titulo;
            this.disciplina = registroAtualizado.disciplina;
            this.serie = registroAtualizado.serie;
        }

        public override string Validar()
        {

            if (titulo == null)
                return $"Você deve inserir um titulo!";
            if (disciplina == null)
                return $"Você deve selecionar uma disciplina!";
            if (serie == null)
                return $"Você deve selecionar uma serie!";

            return "";
        }
    }
}
