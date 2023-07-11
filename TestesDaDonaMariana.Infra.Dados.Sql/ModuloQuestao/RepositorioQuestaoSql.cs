using System.Data.SqlClient;
using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloQuestao
{
    public class RepositorioQuestaoSql : RepositorioBaseSql<Questao, MapeadorQuestao>, IRepositorioQuestao
    {
        protected override string sqlInserir => @"INSERT INTO [TBQUESTAO] 
                                                ([disciplina_id], [materia_id], [alternativa_texto], [enunciado])
                                              VALUES 
                                                (@DISCIPLINA_ID, @MATERIA_ID, @ALTERNATIVA_TEXTO, @ENUNCIADO);                  
                                              SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar => @"UPDATE [TBQUESTAO] 
                                             SET
                                                [disciplina_id] = @DISCIPLINA_ID,
                                                [materia_id] = @MATERIA_ID,
                                                [alternativa_texto] = @ALTERNATIVA_TEXTO,
                                                [enunciado] = @ENUNCIADO
                                             WHERE
                                                [id] = @ID";

        protected override string sqlExcluir => @"DELETE FROM [TBQUESTAO]
                                              WHERE 
                                                [id] = @ID";

        protected override string sqlSelecionarTodos => @"SELECT 
                                                        [id] AS QUESTAO_ID,
                                                        [disciplina_id] AS DISCIPLINA_ID,
                                                        [materia_id] AS MATERIA_ID,
                                                        [alternativa_texto] AS ALTERNATIVA_TEXTO,
                                                        [enunciado] AS QUESTAO_ENUNCIADO
                                                      FROM 
                                                        [TBQUESTAO]";

        protected override string sqlSelecionarPorId => @"SELECT 
                                                        [id] AS QUESTAO_ID,
                                                        [disciplina_id] AS DISCIPLINA_ID,
                                                        [materia_id] AS MATERIA_ID,
                                                        [alternativa_texto] AS ALTERNATIVA_TEXTO,
                                                        [enunciado] AS QUESTAO_ENUNCIADO
                                                      FROM 
                                                        [TBQUESTAO]
                                                      WHERE 
                                                        [id] = @ID";

        public override List<Questao> SelecionarTodos()
        {
            List<Questao> questoes = base.SelecionarTodos();

            return questoes;
        }

        public override Questao SelecionarPorId(int id)
        {
            Questao questao = base.SelecionarPorId(id);

            return questao;
        }
    }
}