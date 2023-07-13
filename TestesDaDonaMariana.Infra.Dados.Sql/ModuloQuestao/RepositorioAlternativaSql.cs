using System.Data.SqlClient;
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
        public List<Alternativa> SelecionarAlternativasPorQuestao(int questaoId)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarAlternativas = conexaoComBanco.CreateCommand();
            comandoSelecionarAlternativas.CommandText = @"SELECT A.[ID], A.[IDLETRA], A.[TEXTO], A.[ALTERNATIVACORRETA]
                                                      FROM [TBALTERNATIVA] A
                                                      INNER JOIN [TBQUESTAO_ALTERNATIVA] QA ON A.[ID] = QA.[alternativa_id]
                                                      WHERE QA.[questao_id] = @QUESTAO_ID;";

            comandoSelecionarAlternativas.Parameters.AddWithValue("@QUESTAO_ID", questaoId);

            SqlDataReader leitorAlternativas = comandoSelecionarAlternativas.ExecuteReader();

            List<Alternativa> alternativas = new List<Alternativa>();

            MapeadorAlternativa mapeador = new MapeadorAlternativa();

            while (leitorAlternativas.Read())
            {
                Alternativa alternativa = mapeador.ConverterRegistro(leitorAlternativas);
                alternativas.Add(alternativa);
            }

            conexaoComBanco.Close();

            return alternativas;
        }

        public void InserirAlternativasParaQuestao(int questaoId, List<Alternativa> alternativas)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            foreach (Alternativa alternativa in alternativas)
            {
                SqlCommand comandoInserirAlternativa = conexaoComBanco.CreateCommand();
                comandoInserirAlternativa.CommandText = @"INSERT INTO [TBALTERNATIVA] ([IDLETRA], [TEXTO], [ALTERNATIVACORRETA])
                                                      VALUES (@IDLETRA, @TEXTO, @ALTERNATIVACORRETA);
                                                      SELECT SCOPE_IDENTITY();";

                comandoInserirAlternativa.Parameters.AddWithValue("@IDLETRA", alternativa.idLetra);
                comandoInserirAlternativa.Parameters.AddWithValue("@TEXTO", alternativa.texto);
                comandoInserirAlternativa.Parameters.AddWithValue("@ALTERNATIVACORRETA", alternativa.alternativaCorreta);

                object id = comandoInserirAlternativa.ExecuteScalar();
                alternativa.id = Convert.ToInt32(id);

                SqlCommand comandoInserirAssociacao = conexaoComBanco.CreateCommand();
                comandoInserirAssociacao.CommandText = @"INSERT INTO [TBQUESTAO_ALTERNATIVA] ([questao_id], [alternativa_id])
                                                     VALUES (@QUESTAO_ID, @ALTERNATIVA_ID);";

                comandoInserirAssociacao.Parameters.AddWithValue("@QUESTAO_ID", questaoId);
                comandoInserirAssociacao.Parameters.AddWithValue("@ALTERNATIVA_ID", alternativa.id);

                comandoInserirAssociacao.ExecuteNonQuery();
            }

            conexaoComBanco.Close();
        }
    }
}
