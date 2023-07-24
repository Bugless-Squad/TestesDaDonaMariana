using System.Data.SqlClient;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloQuestao;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloQuestao;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloMateria
{
    public class RepositorioMateriaSql : 
        RepositorioBaseSql<Materia, MapeadorMateria>, IRepositorioMateria
    {
        public RepositorioMateriaSql(string connectionString) : base(connectionString)
        {

        }        

        protected override string sqlInserir => @"INSERT INTO [dbo].[TBMATERIA]
                                                    (
                                                        [TITULO]
                                                       ,[DISCIPLINA_ID]
                                                       ,[SERIE]
                                                    )
                                                 VALUES
                                                    (
                                                        @TITULO
                                                       ,@DISCIPLINA_ID
                                                       ,@SERIE
                                                    );
                                                 SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar => @"UPDATE [dbo].[TBMATERIA]
                                               SET
                                                   [TITULO] = @TITULO
                                                  ,[DISCIPLINA_ID] = @DISCIPLINA_ID
                                                  ,[SERIE] = @SERIE
                                             WHERE [ID] = @ID;";

        protected override string sqlExcluir => @"DELETE FROM [dbo].[TBMATERIA]
	                                                WHERE 
		                                                [ID] = @ID";

        protected override string sqlSelecionarTodos => @"SELECT 
	                                                        M.[ID]             MATERIA_ID 
	                                                       ,M.[TITULO]         MATERIA_TITULO
                                                           ,M.[SERIE]          MATERIA_SERIE
	                                                       ,D.[ID]             DISCIPLINA_ID
                                                           ,D.[NOME]           DISCIPLINA_NOME
                                                        FROM 
	                                                        [TBMATERIA] AS M

                                                        INNER JOIN [TBDISCIPLINA] AS D
                                                                ON M.[DISCIPLINA_ID] = D.ID";

        protected override string sqlSelecionarPorId => @"SELECT 
	                                                    M.[ID]             MATERIA_ID 
	                                                   ,M.[TITULO]         MATERIA_TITULO
                                                       ,M.[SERIE]          MATERIA_SERIE
	                                                   ,D.[ID]             DISCIPLINA_ID
                                                       ,D.[NOME]           DISCIPLINA_NOME
                                                    FROM 
	                                                    [TBMATERIA] AS M

                                                    INNER JOIN [TBDISCIPLINA] AS D
                                                            ON M.[DISCIPLINA_ID] = D.ID
                                                    WHERE 
                                                        M.[ID] = @ID";

        private string sqlSelecionarPorNome => @"SELECT 
	                                             M.[ID]             MATERIA_ID 
	                                            ,M.[TITULO]         MATERIA_TITULO
                                                ,M.[SERIE]          MATERIA_SERIE
	                                            ,D.[ID]             DISCIPLINA_ID
                                                ,D.[NOME]           DISCIPLINA_NOME

                                            FROM 
	                                                [TBMATERIA] AS M
                
                                                INNER JOIN TBDISCIPLINA AS D                     
                                                    ON M.DISCIPLINA_ID = D.ID

                                            WHERE
                                                M.NOME = @NOME";

        public Materia SelecionarPorNome(string nome)
        {
            SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("NOME", nome) };

            return base.SelecionarRegistroPorParametro(sqlSelecionarPorNome, parametros);
        }

        //public List<Materia> SelecionarTodos()
        //{
        //    List<Materia> materias = base.SelecionarTodos();

        //    return materias;
        //}

        //public Materia SelecionarPorId(int id)
        //{
        //    Materia materia = base.SelecionarPorId(id);

        //    return materia;
        //}

        //public List<Materia> SelecionarMateriasPorTeste(int testeId)
        //{
        //    SqlConnection conexaoComBanco = new SqlConnection(connectionString);
        //    conexaoComBanco.Open();

        //    SqlCommand comandoSelecionarPorTeste = conexaoComBanco.CreateCommand();
        //    comandoSelecionarPorTeste.CommandText = @"SELECT 
        //                                            M.[ID] AS MATERIA_ID,
        //                                            M.[TITULO] AS MATERIA_TITULO,
        //                                            M.[DISCIPLINA_ID] AS DISCIPLINA_ID,
        //                                            M.[SERIE] AS MATERIA_SERIE
        //                                          FROM 
        //                                            [TBMATERIA] AS M
        //                                          INNER JOIN [TBMATERIA_TESTE] AS MT
        //                                              ON M.[ID] = MT.[MATERIA_ID]
        //                                          WHERE 
        //                                            MT.[TESTE_ID] = @TESTE_ID";

        //    comandoSelecionarPorTeste.Parameters.AddWithValue("@TESTE_ID", testeId);

        //    SqlDataReader leitorMaterias = comandoSelecionarPorTeste.ExecuteReader();

        //    List<Materia> materias = new();

        //    MapeadorMateria mapeador = new();

        //    while (leitorMaterias.Read())
        //    {
        //        Materia materia = mapeador.ConverterRegistro(leitorMaterias);
        //        materias.Add(materia);
        //    }

        //    conexaoComBanco.Close();

        //    return materias;
        //}

        //public List<Materia> SelecionarMateriasPorDisciplina(int idDisciplina)
        //{
        //    SqlConnection conexaoComBanco = new SqlConnection(connectionString);
        //    conexaoComBanco.Open();

        //    SqlCommand comandoSelecionarPorDisciplina = conexaoComBanco.CreateCommand();
        //    comandoSelecionarPorDisciplina.CommandText = @"SELECT 
        //                                                [ID] AS MATERIA_ID,
        //                                                [TITULO] AS MATERIA_TITULO,
        //                                                [DISCIPLINA_ID] AS DISCIPLINA_ID,
        //                                                [SERIE] AS MATERIA_SERIE
        //                                              FROM 
        //                                                [TBMATERIA]
        //                                              WHERE 
        //                                                [DISCIPLINA_ID] = @DISCIPLINA_ID";

        //    comandoSelecionarPorDisciplina.Parameters.AddWithValue("@DISCIPLINA_ID", idDisciplina);

        //    SqlDataReader leitorMaterias = comandoSelecionarPorDisciplina.ExecuteReader();

        //    List<Materia> materias = new();
        //    MapeadorMateria mapeador = new();

        //    while (leitorMaterias.Read())
        //    {
        //        Materia materia = mapeador.ConverterRegistroComDisciplina(leitorMaterias);
        //        materias.Add(materia);
        //    }

        //    conexaoComBanco.Close();

        //    return materias;
        //}

        //public  List<Questao> SelecionarQuestoesPorMateria(int materiaId)
        //{
        //    SqlConnection conexaoComBanco = new SqlConnection(connectionString);
        //    conexaoComBanco.Open();

        //    SqlCommand comandoSelecionarQuestoes = conexaoComBanco.CreateCommand();
        //    comandoSelecionarQuestoes.CommandText = @"SELECT Q.[ID],
        //                                                 Q.[ENUNCIADO],
        //                                                 Q.[DISCIPLINA_ID],
        //                                                 Q.[MATERIA_ID],
        //                                                 Q.[ALTERNATIVACORRETA_ID],
        //                                                 D.[NOME] DISCIPLINA_NOME,
        //                                                 M.[TITULO] MATERIA_TITULO
        //                                          FROM [TBQUESTAO] AS Q
        //                                          INNER JOIN [TBDISCIPLINA] AS D ON Q.[DISCIPLINA_ID] = D.[ID]
        //                                          INNER JOIN [TBMATERIA] AS M ON Q.[MATERIA_ID] = M.[ID]
        //                                          WHERE Q.[MATERIA_ID] = @MATERIA_ID";

        //    comandoSelecionarQuestoes.Parameters.AddWithValue("@MATERIA_ID", materiaId);

        //    SqlDataReader leitorQuestoes = comandoSelecionarQuestoes.ExecuteReader();

        //    List<Questao> questoes = new List<Questao>();

        //    MapeadorQuestao mapeador = new MapeadorQuestao();

        //    while (leitorQuestoes.Read())
        //    {
        //        //Questao questao = mapeador.ConverterRegistroComQuestao(leitorQuestoes);
        //       // questoes.Add(questao);
        //    }

        //    conexaoComBanco.Close();

        //    return questoes;
        //}
    }
}