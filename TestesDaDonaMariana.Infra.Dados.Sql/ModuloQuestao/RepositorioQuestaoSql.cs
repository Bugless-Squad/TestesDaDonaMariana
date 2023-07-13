using System.Data.SqlClient;
using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloQuestao
{
    public class RepositorioQuestaoSql : RepositorioBaseSql<Questao, MapeadorQuestao>, IRepositorioQuestao
    {
        protected override string sqlInserir => @"INSERT INTO [TBQUESTAO]
                                              ([ENUNCIADO], [DISCIPLINA_ID], [MATERIA_ID], [ALTERNATIVACORRETA_ID])
                                              VALUES
                                              (@ENUNCIADO, @DISCIPLINA_ID, @MATERIA_ID, @ALTERNATIVACORRETA_ID);
                                              SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar => @"UPDATE [TBQUESTAO]
                                             SET [ENUNCIADO] = @ENUNCIADO,
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
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarQuestoes = conexaoComBanco.CreateCommand();
            comandoSelecionarQuestoes.CommandText = @"SELECT Q.[ID] ID,
                                                         Q.[ENUNCIADO],
                                                         Q.[DISCIPLINA_ID],
                                                         Q.[MATERIA_ID],
                                                         Q.[ALTERNATIVACORRETA_ID],
                                                         D.[NOME] DISCIPLINA_NOME,
                                                         M.[NOME] MATERIA_NOME
                                                  FROM [TBQUESTAO] Q
                                                  INNER JOIN [TBDISCIPLINA] D ON Q.[DISCIPLINA_ID] = D.[ID]
                                                  INNER JOIN [TBMATERIA] M ON Q.[MATERIA_ID] = M.[ID]
                                                  WHERE Q.[MATERIA_ID] = @MATERIA_ID";

            comandoSelecionarQuestoes.Parameters.AddWithValue("@MATERIA_ID", materiaId);

            SqlDataReader leitorQuestoes = comandoSelecionarQuestoes.ExecuteReader();

            List<Questao> questoes = new List<Questao>();

            MapeadorQuestao mapeador = new MapeadorQuestao();

            while (leitorQuestoes.Read())
            {
                Questao questao = mapeador.ConverterRegistro(leitorQuestoes);
                questoes.Add(questao);
            }

            conexaoComBanco.Close();

            return questoes;
        }

        public List<Questao> SelecionarQuestoesPorTeste(int testeId)
        {
            MapeadorQuestao mapeador = new MapeadorQuestao();
            List<Questao> questoes = mapeador.SelecionarQuestoesPorTeste(testeId);

            return questoes;
        }
    }
}