using System.Data.SqlClient;
using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloQuestao
{
    public class RepositorioQuestaoSql : RepositorioBaseSql<Questao, MapeadorQuestao>, IRepositorioQuestao
    {
        protected override string sqlInserir => @"INSERT INTO[DBO].[QUESTAO]
                                                    (
                                                        [ENUNCIADO]
                                                       ,[MATERIA_ID]
                                                       ,[RESPOSTA]
                                                    )
                                                 VALUES
                                                    (
                                                        @ENUNCIADO
                                                       ,@MATERIA_ID
                                                       ,@RESPOSTACERTA
                                                    );
                                                 SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar => @"UPDATE[QUESTAO]
                                               SET
                                                   [MATERIA_ID] = @MATERIA_ID
                                                  ,[ENUNCIADO] = @ENUNCIADO
                                                  ,[RESPOSTA] = @RESPOSTACERTA
                                             WHERE [ID] = @ID;";

        protected override string sqlExcluir => @"DELETE FROM [QUESTAO]
                                                    WHERE 
                                                        [ID] = @ID";

        protected override string sqlSelecionarTodos => @"SELECT 
	                                                        Q.[ID]                QUESTAO_ID 
	                                                       ,Q.[ENUNCIADO]         QUESTAO_ENUNCIADO
	                                                       ,Q.[MATERIA_ID]        MATERIA_ID
                                                           ,Q.[RESPOSTA]          QUESTAO_RESPOSTA
                                                           ,M.[NOME]              MATERIA_NOME
                                                           ,M.[SERIE]             MATERIA_SERIE
                                                           ,M.[DISCIPLINA_ID]     DISCIPLINA_ID
                                                           ,D.[NOME]              DISCIPLINA_NOME
                                                        FROM 
	                                                        [QUESTAO] AS Q
                                                        INNER JOIN [TBMATERIA] AS M
                                                                ON Q.[MATERIA_ID] = M.ID
                                                        INNER JOIN [DISCIPLINA] AS D
                                                                ON M.[DISCIPLINA_ID] = D.ID";

        protected override string sqlSelecionarPorId => @"SELECT 
	                                                        Q.[ID]                QUESTAO_ID 
	                                                       ,Q.[MATERIA_ID]        MATERIA_ID
	                                                       ,Q.[ENUNCIADO]         QUESTAO_ENUNCIADO
                                                           ,Q.[RESPOSTA]          QUESTAO_RESPOSTA
                                                           ,M.[NOME]              MATERIA_NOME
                                                           ,M.[SERIE]             MATERIA_SERIE
                                                           ,M.[DISCIPLINA_ID]     DISCIPLINA_ID
                                                           ,D.[NOME]   DISCIPLINA_NOME
                                                    FROM 
	                                                        [QUESTAO] AS Q
                                                        INNER JOIN [TBMATERIA] AS M
                                                                ON Q.[MATERIA_ID] = M.ID
                                                        INNER JOIN [DISCIPLINA] AS D
                                                                ON M.[DISCIPLINA_ID] = D.ID
                                                    WHERE 
                                                        Q.[ID] = @ID";

        private string sqlAdicionarAlternativa =>
                                              @"INSERT INTO [TBAlternativa]
                                                        (
                                                            [QUESTAO_ID]
                                                           ,[TEXTO]
                                                           ,[ALTERNATIVA]
                                                        )
                                                    VALUES
                                                        (
                                                           @QUESTAO_ID
                                                           ,@TEXTO
                                                           ,@ALTERNATIVA
                                                        )";

        private string sqlCarregarAlternativas =>
            @"SELECT 
                            A.ID            ALTERNATIVA_ID, 
                            A.TEXTO         ALTERNATIVA_QUESTAO,
                            A.ALTERNATIVA   ALTERNATIVA_ALTERNATIVA,
                            A.QUESTAO_ID    QUESTAO_ID,

                            Q.MATERIA_ID    MATERIA_ID,
                            Q.ENUNCIADO     QUESTAO_ENUNCIADO,
                            Q.RESPOSTA      QUESTAO_RESPOSTA,

                            M.NOME           MATERIA_NOME,
                            M.DISCIPLINA_ID  DISCIPLINA_ID,
                            M.SERIE          MATERIA_SERIE,

                            D.NOME           DISCIPLINA_NOME
                        FROM 
                            TBALTERNATIVA A

                            INNER JOIN QUESTAO Q

                                ON Q.ID = A.QUESTAO_ID

                            INNER JOIN TBMATERIA M

                                ON Q.MATERIA_ID = M.ID

                            INNER JOIN DISCIPLINA D

                                ON M.DISCIPLINA_ID = D.ID
                        WHERE 

                            A.QUESTAO_ID = @QUESTAO_ID AND Q.MATERIA_ID = @MATERIA_ID AND M.DISCIPLINA_ID = @DISCIPLINA_ID";

        private const string sqlRemoverAlternativas =
            @"DELETE FROM [TBALTERNATIVA]
                            WHERE
                                [QUESTAO_ID] = @QUESTAO_ID";

        public override void Excluir(Questao questao)
        {
            RemoverAlternativa(questao);

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("ID", questao.id);

            conexaoComBanco.Open();

            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        public override Questao SelecionarPorId(int id)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarPorId = conexaoComBanco.CreateCommand();
            comandoSelecionarPorId.CommandText = sqlSelecionarPorId;

            //adicionar parametro
            comandoSelecionarPorId.Parameters.AddWithValue("ID", id);

            //executa o comando
            SqlDataReader leitorTemas = comandoSelecionarPorId.ExecuteReader();

            Questao questao = null;

            if (leitorTemas.Read())
            {
                MapeadorQuestao mapeador = new MapeadorQuestao();
                questao = mapeador.ConverterRegistro(leitorTemas);
            }
            //encerra a conexão
            conexaoComBanco.Close();

            if (questao != null)
            {
                CarregarAlternativas(questao);
            }
            return questao;
        }

        private void CarregarAlternativas(Questao questao)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarAlternativas = conexaoComBanco.CreateCommand();
            comandoSelecionarAlternativas.CommandText = sqlCarregarAlternativas;

            comandoSelecionarAlternativas.Parameters.AddWithValue("QUESTAO_ID", questao.id);
            comandoSelecionarAlternativas.Parameters.AddWithValue("MATERIA_ID", questao.materia.id);
            comandoSelecionarAlternativas.Parameters.AddWithValue("DISCIPLINA_ID", questao.materia.disciplina.id);

            SqlDataReader leitorAlternativa = comandoSelecionarAlternativas.ExecuteReader();

            while (leitorAlternativa.Read())
            {
                MapeadorQuestao mapeador = new MapeadorQuestao();

                Alternativa alternativa = mapeador.ConverterParaAlternativa(leitorAlternativa);

                questao.AdicionarAlternativa(alternativa);
            }

            conexaoComBanco.Close();
        }

        private void RemoverAlternativa(Questao questao)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlRemoverAlternativas, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("QUESTAO_ID", questao.id);

            conexaoComBanco.Open();
            comandoExclusao.ExecuteNonQuery();

            conexaoComBanco.Close();
        }
    }
}