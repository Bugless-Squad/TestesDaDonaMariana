using TestesDaDonaMariana.Dominio.Compartilhado;

namespace TestesDaDonaMariana.Dominio.ModuloTeste
{
    public class Teste : EntidadeBase<Teste>
    {
        public Teste()
        {
            
        }

        public override void AtualizarInformacoes(Teste registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
