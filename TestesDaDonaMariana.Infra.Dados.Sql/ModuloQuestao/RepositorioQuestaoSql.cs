using System.Data.SqlClient;
using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloQuestao
{
    public class RepositorioQuestaoSql : RepositorioBaseSql<Questao, MapeadorQuestao> ,IRepositorioQuestao
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
                                                           ,[RESPOSTA]
                                                           ,[VERDADEIRO]
                                                        )
                                                    VALUES
                                                        (
                                                           @QUESTAO_ID
                                                           ,@RESPOSTA
                                                           ,@VERDADEIRO
                                                        )";

        private string sqlCarregarAlternativas =>
            @"SELECT 
                            A.ID            ALTERNATIVA_ID, 
                            A.RESPOSTA      ALTERNATIVA_RESPOSTA,
                            A.VERDADEIRO    ALTERNATIVA_VERDADEIRO,
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
        public void Inserir(Questao questao, List<Alternativa> alternativasAdicionadas)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoInserir = conexaoComBanco.CreateCommand();
            comandoInserir.CommandText = sqlInserir;

            MapeadorQuestao mapeador = new MapeadorQuestao();
            mapeador.ConfigurarParametros(comandoInserir, questao);

            object id = comandoInserir.ExecuteScalar();

            questao.id = Convert.ToInt32(id);

            conexaoComBanco.Close();

            foreach (Alternativa alternativa in alternativasAdicionadas)
            {
                if (questao.alternativas.Contains(alternativa) == false)
                {
                    AdicionarAlternativa(alternativa, questao);
                }
            }
        }

        public void Editar(int id, Questao questao, List<Alternativa> alternativas)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoEditar = conexaoComBanco.CreateCommand();
            comandoEditar.CommandText = sqlEditar;

            MapeadorQuestao mapeador = new MapeadorQuestao();
            mapeador.ConfigurarParametros(comandoEditar, questao);

            comandoEditar.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

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

        public List<Questao> SelecionarTodos(bool carregarItens = false, bool carregarQuestoes = false)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarTodos = conexaoComBanco.CreateCommand();
            comandoSelecionarTodos.CommandText = sqlSelecionarTodos;

            SqlDataReader leitorTemas = comandoSelecionarTodos.ExecuteReader();

            List<Questao> questoes = new List<Questao>();

            while (leitorTemas.Read())
            {
                MapeadorQuestao mapeador = new MapeadorQuestao();
                Questao questao = mapeador.ConverterRegistro(leitorTemas);

                if (carregarItens)
                    CarregarAlternativas(questao);

                questoes.Add(questao);
            }

            conexaoComBanco.Close();

            return questoes;
        }

        private void AdicionarAlternativa(Alternativa alternativa, Questao questao)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoInserir = conexaoComBanco.CreateCommand();
            comandoInserir.CommandText = sqlAdicionarAlternativa;

            comandoInserir.Parameters.AddWithValue("QUESTAO_ID", questao.id);
            //      comandoInserir.Parameters.AddWithValue("RESPOSTA", alternativa.alternativaCorreta);
            comandoInserir.Parameters.AddWithValue("VERDADEIRO", alternativa.alternativaCorreta);

            comandoInserir.ExecuteNonQuery();

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

        private void CarregarAlternativas(Questao questao)
        {
            throw new NotImplementedException();
        }

        public void Editar(Questao registroSelecionado, Questao registroAtualizado)
        {
            throw new NotImplementedException();
        }
    }
}