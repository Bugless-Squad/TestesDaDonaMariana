using TestesDaDonaMariana.Dominio.Compartilhado;
using TestesDaDonaMariana.Dominio.ModuloMateria;

namespace TestesDaDonaMariana.Dominio.ModuloTeste
{
    public class Teste : EntidadeBase<Teste>
    {
        public string titulo { get; set; }
        public int numQuestoes { get; set; }
        public Materia materia { get; set; }
        public DateTime dataCriacao { get; set; }
        public Teste()
        {
            
        }
        public Teste(int id, Materia materia, int numQuestoes, DateTime datacriacao)
        {
            this.id = id;
            this.materia = materia;
            this.numQuestoes = numQuestoes;
            this.dataCriacao = dataCriacao;
        }

        public override void AtualizarInformacoes(Teste registroAtualizado)
        {
            materia = registroAtualizado.materia;

        }

        public override string Validar()
        {
            Validador valida = new();

            if (materia == null)
                return $"Você deve selecionar uma materia!";

            return "";
        }
    }
}
