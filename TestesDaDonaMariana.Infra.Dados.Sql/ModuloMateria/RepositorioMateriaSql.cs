using System.Data.SqlClient;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloQuestao;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloQuestao;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloMateria
{
    public class RepositorioMateriaSql : RepositorioBaseSql<Materia, MapeadorMateria>, IRepositorioMateria
    {
        protected override string sqlInserir => @"INSERT INTO[DBO].[TBMATERIA]
                                                    (
                                                        [NOME]
                                                       ,[DISCIPLINA_ID]
                                                       ,[SERIE]
                                                    )
                                                 VALUES
                                                    (
                                                        @NOME
                                                       ,@DISCIPLINA_ID
                                                       ,@SERIE
                                                    );
                                                 SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar => @"UPDATE[TBMATERIA]
                                               SET
                                                   [NOME] = @NOME
                                                  ,[DISCIPLINA_ID] = @DISCIPLINA_ID
                                                  ,[SERIE] = @SERIE
                                             WHERE [ID] = @ID;";

        protected override string sqlExcluir => @"DELETE FROM [TBMATERIA]
	                                                WHERE 
		                                                [ID] = @ID";

        protected override string sqlSelecionarTodos => @"SELECT 
	                                                        M.[ID]        MATERIA_ID 
	                                                       ,M.[NOME]      MATERIA_NOME
	                                                       ,M.[DISCIPLINA_ID]  DISCIPLINA_ID
                                                           ,M.[SERIE]     MATERIA_SERIE
                                                           ,D.[NOME]        DISCIPLINA_NOME
                                                        FROM 
	                                                        [TBMATERIA] AS M
                                                        INNER JOIN [TBDISCIPLINA] AS D
                                                                ON M.[DISCIPLINA_ID] = D.ID";

        protected override string sqlSelecionarPorId => @"SELECT 
	                                                    M.[ID]        MATERIA_ID 
	                                                   ,M.[NOME]      MATERIA_NOME
	                                                   ,M.[DISCIPLINA_ID]  DISCIPLINA_ID
                                                       ,M.[SERIE]     MATERIA_SERIE
                                                       ,D.[NOME]      DISCIPLINA_NOME
                                                    FROM 
	                                                    [TBMATERIA] AS M
                                                    INNER JOIN [TBDISCIPLINA] AS D
                                                            ON M.[DISCIPLINA_ID] = D.ID
                                                    WHERE 
                                                        M.[ID] = @ID";

        public override List<Materia> SelecionarTodos()
        {
            List<Materia> materias = base.SelecionarTodos();

            return materias;
        }

        public override Materia SelecionarPorId(int id)
        {
            Materia materia = base.SelecionarPorId(id);

            return materia;
        }

        public List<Materia> SelecionarMateriasPorDisciplina(int idDisciplina)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarPorDisciplina = conexaoComBanco.CreateCommand();
            comandoSelecionarPorDisciplina.CommandText = @"SELECT 
                                                        [id] AS MATERIA_ID,
                                                        [nome] AS MATERIA_NOME,
                                                        [disciplina_id] AS DISCIPLINA_ID,
                                                        [serie] AS MATERIA_SERIE
                                                      FROM 
                                                        [TBMATERIA]
                                                      WHERE 
                                                        [disciplina_id] = @DISCIPLINA_ID";

            comandoSelecionarPorDisciplina.Parameters.AddWithValue("@DISCIPLINA_ID", idDisciplina);

            SqlDataReader leitorMaterias = comandoSelecionarPorDisciplina.ExecuteReader();

            List<Materia> materias = new();
            MapeadorMateria mapeador = new();

            while (leitorMaterias.Read())
            {
                Materia materia = mapeador.ConverterRegistroComDisciplina(leitorMaterias);
                materias.Add(materia);
            }

            conexaoComBanco.Close();

            return materias;
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
    }
}