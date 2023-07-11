using Microsoft.Win32;
using System.Data.SqlClient;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloQuestao;
using TestesDaDonaMariana.Dominio.ModuloTeste;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloQuestao;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloTeste
{
    public class RepositorioTesteSql : RepositorioBaseSql<Teste, MapeadorTeste>, IRepositorioTeste
    {
        protected override string sqlInserir => @"INSERT INTO[DBO].[TBTESTE]
                                                    (
                                                        [TITULO]
                                                       ,[DISCIPLINA_ID]
                                                       ,[MATERIA_ID]
                                                       ,[QUANTIDADEQUESTOES]
                                                    )
                                                 VALUES
                                                    (
                                                        @TITULO
                                                       ,@DISCIPLINA_ID
                                                       ,@MATERIA_ID
                                                       ,@QUANTIDADEQUESTOES
                                                    );
                                                 SELECT SCOPE_IDENTITY();";


        protected override string sqlEditar => @"UPDATE[TBTESTE]
                                               SET
                                                   [TITULO] = @TITULO
                                                   ,[DISCIPLINA_ID] = @DISCIPLINA_ID
                                                   ,[MATERIA_ID] = @MATERIA_ID
                                                   ,[QUANTIDADEQUESTOES] = @QUANTIDADEQUESTOES
                                             WHERE [ID] = @ID;";

        protected override string sqlExcluir => @"DELETE FROM [TBTESTE]
	                                                WHERE 
		                                                [ID] = @ID";

        protected override string sqlSelecionarPorId => @"SELECT 
	                                                        T.[ID]                  TESTE_ID 
                                                           ,T.[TITULO]              TESTE_TITULO
	                                                       ,T.[DISCIPLINA_ID]       TESTE_DISCIPLINA_ID
	                                                       ,T.[MATERIA_ID]          TESTE_MATERIA_ID
                                                           ,T.[QUANTIDADEQUESTOES]  TESTE_QUANTIDADEQUESTOES
                                                           ,M.[ID]                  MATERIA_ID
                                                           ,M.[NOME]                MATERIA_NOME
                                                           ,M.[SERIE]               MATERIA_SERIE
                                                           ,M.[DISCIPLINA_ID]       DISCIPLINA_ID
                                                           ,D.[ID]                  DISCIPLINA_ID
                                                           ,D.[NOME]                DISCIPLINA_NOME
                                                    FROM 
	                                                        [TBTESTE] AS T
                                                        INNER JOIN [TBMATERIA] AS M
                                                                ON T.[MATERIA_ID] = M.ID
                                                        INNER JOIN [DISCIPLINA] AS D
                                                                ON M.[DISCIPLINA_ID] = D.ID
                                                    WHERE 
                                                        T.[ID] = @ID";

        protected override string sqlSelecionarTodos => @"SELECT 
	                                                        T.[ID]                  TESTE_ID 
                                                           ,T.[TITULO]              TESTE_TITULO
	                                                       ,T.[DISCIPLINA_ID]       TESTE_DISCIPLINA_ID
	                                                       ,T.[MATERIA_ID]          TESTE_MATERIA_ID
                                                           ,T.[QUANTIDADEQUESTOES]  TESTE_QUANTIDADEQUESTOES
                                                           ,M.[ID]                  MATERIA_ID
                                                           ,M.[NOME]                MATERIA_NOME
                                                           ,M.[SERIE]               MATERIA_SERIE
                                                           ,M.[DISCIPLINA_ID]       DISCIPLINA_ID
                                                           ,D.[ID]                  DISCIPLINA_ID
                                                           ,D.[NOME]                DISCIPLINA_NOME

                                                        FROM 
	                                                        [TBTESTE] AS T
                                                        INNER JOIN [TBMATERIA] AS M
                                                                ON T.[MATERIA_ID] = M.ID
                                                        INNER JOIN [DISCIPLINA] AS D
                                                                ON M.[DISCIPLINA_ID] = D.ID";


        private const string sqlAdicionarQuestao = @"INSERT INTO [TBQUESTAO_TBTESTE]
                                                    (
                                                        [Questao_Id]
                                                       ,[Teste_Id])
                                                VALUES
                                                    (
                                                        @Questao_Id
                                                       ,@Teste_Id
                                                    )";

        private const string sqlCarregarQuestoes = @"SELECT 
                                                            Q.ID            QUESTAO_ID, 
                                                            Q.MATERIA_ID    QUESTAO_MATERIA_ID, 
                                                            Q.ENUNCIADO     QUESTAO_ENUNCIADO,
                                                            Q.RESPOSTA      QUESTAO_RESPOSTA,
                
                                                            M.ID             MATERIA_ID,
                                                            M.NOME           MATERIA_NOME,
                                                            M.DISCIPLINA_ID  DISCIPLINA_ID,
                                                            M.SERIE          MATERIA_SERIE,

                                                            D.ID             DISCIPLINA_ID,
                                                            D.NOME           DISCIPLINA_NOME
                                                        FROM 
                                                            [QUESTAO] Q

                                                            INNER JOIN TBMATERIA M

                                                                ON Q.MATERIA_ID = M.ID

                                                            INNER JOIN DISCIPLINA D

                                                                ON M.DISCIPLINA_ID = D.ID
                                                        WHERE 

                                                            Q.MATERIA_ID = @MATERIA_ID AND M.DISCIPLINA_ID = @DISCIPLINA_ID";


        private const string sqlRemoverQuestoes = @"DELETE FROM TBQUESTAO_TBTESTE
                                                       WHERE TESTE_ID = @TESTE_ID AND QUESTAO_ID = @QUESTAO_ID";


        private const string sqlCarregasQuestoesTeste = @"SELECT 
                                                            Q.ID                QUESTAO_ID, 
                                                            Q.MATERIA_ID        QUESTAO_MATERIA_ID, 
                                                            Q.ENUNCIADO         QUESTAO_ENUNCIADO,
                                                            Q.RESPOSTA          QUESTAO_RESPOSTA,

                                                            TBT.TESTE_ID        TESTE_ID,
                
                                                            M.ID                MATERIA_ID,
                                                            M.NOME              MATERIA_NOME,
                                                            M.DISCIPLINA_ID     DISCIPLINA_ID,
                                                            M.SERIE             MATERIA_SERIE,

                                                            D.ID             DISCIPLINA_ID,
                                                            D.NOME           DISCIPLINA_NOME
                
                                                        FROM 
                                                            [QUESTAO] Q

                                                            INNER JOIN TBQUESTAO_TBTESTE TBT
                                                                ON Q.ID = TBT.QUESTAO_ID

                                                            INNER JOIN TBMATERIA M
                                                                ON Q.MATERIA_ID = M.ID
    
                                                            INNER JOIN DISCIPLINA D
                                                                ON M.DISCIPLINA_ID = D.ID

                                                        WHERE 

                                                            TBT.TESTE_ID = @TESTE_ID";



        public void CarregarQuestoes(Teste teste)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarItens = conexaoComBanco.CreateCommand();
            comandoSelecionarItens.CommandText = sqlCarregasQuestoesTeste;

            Materia materia = new();

            if (teste.materias.Count > 1)
            {
                materia.titulo = "Todas";
                materia.id = teste.materias.Max(x => x.id + 1);
            }
            else
                materia = teste.materias.FirstOrDefault(x => x == teste.materias[0]);


            comandoSelecionarItens.Parameters.AddWithValue("TESTE_ID", teste.id);
            comandoSelecionarItens.Parameters.AddWithValue("MATERIA_ID", teste.id);
            comandoSelecionarItens.Parameters.AddWithValue("DISCIPLINA_ID", teste.disciplina.id);

            SqlDataReader leitorQuestao = comandoSelecionarItens.ExecuteReader();

            while (leitorQuestao.Read())
            {
                MapeadorQuestao mapeador = new MapeadorQuestao();

                Questao questao = mapeador.ConverterRegistro(leitorQuestao);

                teste.AdicionarQuestao(questao);
            }

            conexaoComBanco.Close();
        }

        public Teste SelecionarPorId(int id)
        {
            Teste teste = base.SelecionarPorId(id);

            if (teste != null)
                CarregarQuestoes(teste);

            return teste;
        }

        public List<Teste> SelecionarTodos()
        {
            List<Teste> testes = base.SelecionarTodos();

            return testes;
        }
    }
}
