using System.Drawing.Drawing2D;
using System.Security.Cryptography.X509Certificates;
using TestesDaDonaMariana.Dominio.Compartilhado;
using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public string titulo { get; set; }
        public Disciplina disciplina { get; set; }
        public OpcoesSerieEnum opcoesSerie { get; set; }

        public Questao questao { get; set; }  //qtdCadastrada


        public Materia () 
        {

        }
        public override void AtualizarInformacoes(Materia registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
