using System.Data.SqlClient;
using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloQuestao
{
    public class RepositorioQuestaoSql : RepositorioBaseSql<Questao, MapeadorQuestao>, IRepositorioQuestao
    {
        protected override string sqlInserir => @"INSERT INTO [dbo].[TBQUESTAO]
                                                             (
                                                                    [disciplina_id]
                                                                   ,[materia_id]
                                                                   ,[alternativaCorreta_Id]
                                                                   ,[enunciado]
                                                             )
                                                       VALUES
                                                             (
                                                                    @ENUNCIADO
                                                                   ,@DISCIPLINA_ID
                                                                   ,@MATERIA_ID
                                                                   ,@ALTERNATIVACORRETA_ID
                                                             );
                                                       SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar => @"UPDATE [dbo].[TBQUESTAO]
                                             SET 
                                                 [ENUNCIADO] = @ENUNCIADO,
                                                 [DISCIPLINA_ID] = @DISCIPLINA_ID,
                                                 [MATERIA_ID] = @MATERIA_ID,
                                                 [ALTERNATIVACORRETA_ID] = @ALTERNATIVACORRETA_ID
                                             WHERE [ID] = @ID;";

        protected override string sqlExcluir => @"DELETE FROM [TBQUESTAO]
                                              WHERE [ID] = @ID;";

        protected override string sqlSelecionarTodos => @"SELECT [ID], [ENUNCIADO], [DISCIPLINA_ID], [MATERIA_ID], [ALTERNATIVACORRETA_ID]
                                                      FROM [TBQUESTAO];";

        protected override string sqlSelecionarPorId => @"SELECT [ID], [ENUNCIADO], [DISCIPLINA_ID], [MATERIA_ID], [ALTERNATIVACORRETA_ID]
                                                     FROM [TBQUESTAO]
                                                     WHERE [ID] = @ID;";

        public Questao SelecionarPorId(int id)
        {
            Questao questao = base.SelecionarPorId(id);

            return questao;
        }

        public List<Questao> SelecionarTodos()
        {
            List<Questao> questoes = base.SelecionarTodos();

            return questoes;
        }

        public List<Questao> SelecionarQuestoesPorMateria(int materiaId)
        {
            SqlConnection conexaoComBanco = new SqlConnection(connectionString);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarQuestoes = conexaoComBanco.CreateCommand();
            comandoSelecionarQuestoes.CommandText = @"SELECT [ID] AS QUESTAO_ID,
                                                         [ENUNCIADO] AS QUESTAO_ENUNCIADO,
                                                         [DISCIPLINA_ID] AS DISCIPLINA_ID,
                                                         [MATERIA_ID] AS MATERIA_ID,
                                                         [ALTERNATIVACORRETA_ID] AS ALTERNATIVACORRETA_ID
                                                       FROM 
                                                         [TBQUESTAO] 
                                                       WHERE 
                                                         [MATERIA_ID] = @MATERIA_ID";

            comandoSelecionarQuestoes.Parameters.AddWithValue("@MATERIA_ID", materiaId);

            SqlDataReader leitorQuestoes = comandoSelecionarQuestoes.ExecuteReader();

            List<Questao> questoes = new List<Questao>();

            MapeadorQuestao mapeador = new MapeadorQuestao();

            while (leitorQuestoes.Read())
            {
                Questao questao = mapeador.ConverterRegistroComMateria(leitorQuestoes);
                questoes.Add(questao);
            }

            conexaoComBanco.Close();

            return questoes;
        }

        public List<Questao> SelecionarQuestoesPorTeste(int testeId)
        {
            SqlConnection conexaoComBanco = new SqlConnection(connectionString);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarPorTeste = conexaoComBanco.CreateCommand();
            comandoSelecionarPorTeste.CommandText = @"SELECT 
                                                    Q.[id] AS ID,
                                                    Q.[enunciado] AS ENUNCIADO,
                                                    Q.[disciplina_id] AS DISCIPLINA_ID,
                                                    Q.[materia_id] AS MATERIA_ID,
                                                    Q.[alternativaCorreta_id] AS ALTERNATIVACORRETA_ID
                                                  FROM 
                                                    [TBQUESTAO] AS Q
                                                  INNER JOIN [TBTESTE_QUESTAO] AS TQ
                                                      ON Q.[id] = TQ.[questao_id]
                                                  WHERE 
                                                    TQ.[teste_id] = @TESTE_ID;";

            comandoSelecionarPorTeste.Parameters.AddWithValue("@TESTE_ID", testeId);

            SqlDataReader leitorQuestoes = comandoSelecionarPorTeste.ExecuteReader();

            List<Questao> questoes = new List<Questao>();

            MapeadorQuestao mapeador = new();
            while (leitorQuestoes.Read())
            {
                Questao questao = mapeador.ConverterRegistro(leitorQuestoes);
                questoes.Add(questao);
            }

            conexaoComBanco.Close();

            return questoes;
        }
    }
}