using TestesDaDonaMariana.Dominio.ModuloTeste;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloTeste
{
    public class RepositorioTesteJson : RepositorioBaseArquivo<Teste>, IRepositorioTeste
    {
        public RepositorioTesteJson(ContextoDeDados contexto) : base(contexto)
        {
            
        }

        protected override List<Teste> ObterRegistros()
        {
            return contextoDeDados.testes;
        }
    }
}
