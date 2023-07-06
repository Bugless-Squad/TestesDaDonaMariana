using TestesDaDonaMariana.Dominio.ModuloMateria;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloMateria
{
    public class RepositorioMateriaJson : RepositorioBaseArquivo<Materia>, IRepositorioMateria
    {
        public RepositorioMateriaJson(ContextoDeDados contexto) : base(contexto)
        {
            
        }

        protected override List<Materia> ObterRegistros()
        {
            return contextoDeDados.materias;
        }
    }
}