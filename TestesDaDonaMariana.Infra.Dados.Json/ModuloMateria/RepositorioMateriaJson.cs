using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloQuestao;

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

        public List<Materia> SelecionarMateriasPorTeste(int id)
        {
            throw new NotImplementedException();
        }

        public List<Questao> SelecionarQuestoesPorMateria(int id)
        {
            throw new NotImplementedException();
        }

        protected override List<Materia> ObterRegistros()
        {
            return contextoDeDados.materias;
        }
    }
}