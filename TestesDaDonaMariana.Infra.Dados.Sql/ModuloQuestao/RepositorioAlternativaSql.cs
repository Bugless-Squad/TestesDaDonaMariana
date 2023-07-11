using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloQuestao
{
    public class RepositorioAlternativaSql : RepositorioBaseSql<Alternativa, MapeadorAlternativa>, IRepositorioAlternativa
    {
        protected override string sqlInserir => @"INSERT INTO [TBALTERNATIVA] 
                                                ([idContador], [idLetra], [texto], [alternativaCorreta])
                                              VALUES 
                                                (@IDCONTADOR, @IDLETRA, @TEXTO, @ALTERNATIVACORRETA);                  
                                              SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar => @"UPDATE [TBALTERNATIVA] 
                                             SET
                                                [idContador] = @IDCONTADOR,
                                                [idLetra] = @IDLETRA,
                                                [texto] = @TEXTO,
                                                [alternativaCorreta] = @ALTERNATIVACORRETA
                                             WHERE
                                                [id] = @ID";

        protected override string sqlExcluir => @"DELETE FROM [TBALTERNATIVA]
                                              WHERE 
                                                [id] = @ID";

        protected override string sqlSelecionarTodos => @"SELECT 
                                                        [id] AS ALTERNATIVA_ID,
                                                        [idContador] AS ALTERNATIVA_IDCONTADOR,
                                                        [idLetra] AS ALTERNATIVA_IDLETRA,
                                                        [texto] AS ALTERNATIVA_TEXTO,
                                                        [alternativaCorreta] AS ALTERNATIVA_ALTERNATIVACORRETA
                                                      FROM 
                                                        [TBALTERNATIVA]";

        protected override string sqlSelecionarPorId => @"SELECT 
                                                        [id] AS ALTERNATIVA_ID,
                                                        [idContador] AS ALTERNATIVA_IDCONTADOR,
                                                        [idLetra] AS ALTERNATIVA_IDLETRA,
                                                        [texto] AS ALTERNATIVA_TEXTO,
                                                        [alternativaCorreta] AS ALTERNATIVA_ALTERNATIVACORRETA
                                                      FROM 
                                                        [TBALTERNATIVA]
                                                      WHERE 
                                                        [id] = @ID";

        public override List<Alternativa> SelecionarTodos()
        {
            List<Alternativa> alternativas = base.SelecionarTodos();

            return alternativas;
        }

        public override Alternativa SelecionarPorId(int id)
        {
            Alternativa alternativa = base.SelecionarPorId(id);

            return alternativa;
        }
    }
}
