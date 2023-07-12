using TestesDaDonaMariana.Dominio.ModuloMateria;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloMateria
{
    public class RepositorioMateriaJson : RepositorioBaseArquivo<Materia>, IRepositorioMateria
    {
        public RepositorioMateriaJson(ContextoDeDados contexto) : base(contexto)
        {
            
        }

        public List<Materia> SelecionarMateriasPorDisciplina(int idDisciplina)
        {
            throw new NotImplementedException();
        }

        protected override List<Materia> ObterRegistros()
        {
            return contextoDeDados.materias;
        }
    }
}