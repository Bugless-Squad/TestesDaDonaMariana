using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloQuestao
{
    public class RepositorioAlternativaSql : RepositorioBaseSql<Alternativa, MapeadorAlternativa>, IRepositorioAlternativa
    {
        protected override string sqlInserir => @"INSERT INTO [TBALTERNATIVA]
                                              ([IDLETRA], [TEXTO], [ALTERNATIVACORRETA])
                                              VALUES
                                              (@IDLETRA, @TEXTO, @ALTERNATIVACORRETA);
                                              SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar => @"UPDATE [TBALTERNATIVA]
                                             SET [IDLETRA] = @IDLETRA,
                                                 [TEXTO] = @TEXTO,
                                                 [ALTERNATIVACORRETA] = @ALTERNATIVACORRETA
                                             WHERE [ID] = @ID;";

        protected override string sqlExcluir => @"DELETE FROM [TBALTERNATIVA]
                                              WHERE [ID] = @ID;";

        protected override string sqlSelecionarTodos => @"SELECT [ID], [IDLETRA], [TEXTO], [ALTERNATIVACORRETA]
                                                      FROM [TBALTERNATIVA];";

        protected override string sqlSelecionarPorId => @"SELECT [ID], [IDLETRA], [TEXTO], [ALTERNATIVACORRETA]
                                                     FROM [TBALTERNATIVA]
                                                     WHERE [ID] = @ID;";

        public Alternativa SelecionarPorId(int id)
        {
            Alternativa alternativa = base.SelecionarPorId(id);

            return alternativa;
        }

        public List<Alternativa> SelecionarTodos()
        {
            List<Alternativa> alternativas = base.SelecionarTodos();

            return alternativas;
        }
    }
}
