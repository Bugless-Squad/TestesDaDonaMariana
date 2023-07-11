using System.Data.SqlClient;
using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Infra.Dados.Sql.Compartilhado;

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
	                                                        M.[ID]              MATERIA_ID 
	                                                       ,M.[NOME]            MATERIA_NOME
	                                                       ,M.[DISCIPLINA_ID]   DISCIPLINA_ID
                                                           ,M.[SERIE]           MATERIA_SERIE
                                                           ,D.[NOME]            DISCIPLINA_NOME
                                                        FROM 
	                                                        [TBMATERIA] AS M
                                                        INNER JOIN [DISCIPLINA] AS D
                                                                ON M.[DISCIPLINA_ID] = D.ID";

        protected override string sqlSelecionarPorId => @"SELECT 
	                                                    M.[ID]             MATERIA_ID 
	                                                   ,M.[NOME]           MATERIA_NOME
	                                                   ,M.[DISCIPLINA_ID]  DISCIPLINA_ID
                                                       ,M.[SERIE]          MATERIA_SERIE
                                                       ,D.[NOME]           DISCIPLINA_NOME
                                                    FROM 
	                                                    [TBMATERIA] AS M
                                                    INNER JOIN [DISCIPLINA] AS D
                                                            ON M.[DISCIPLINA_ID] = D.ID
                                                    WHERE 
                                                        M.[ID] = @ID";

        private string sqlSelecionarMateriaNaDisciplina => @"SELECT * FROM [TBMATERIA] 
	                                                          WHERE
		                                                        DISCIPLINA_ID = @DISCIPLINA_ID";

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

        public List<Materia> CarregarMateriasDisciplina(Disciplina disciplina)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarMaterias = conexaoComBanco.CreateCommand();
            comandoSelecionarMaterias.CommandText = sqlSelecionarMateriaNaDisciplina;

            comandoSelecionarMaterias.Parameters.AddWithValue("DISCIPLINA_ID", disciplina.id);
            comandoSelecionarMaterias.Parameters.AddWithValue("DISCIPLINA_NOME", disciplina.nome);

            SqlDataReader leitorMateria = comandoSelecionarMaterias.ExecuteReader();

            List<Materia> materias = new List<Materia>();

            while (leitorMateria.Read())
            {
                MapeadorMateria mapeador = new MapeadorMateria();

                Materia materia = mapeador.ConverterMateria(leitorMateria);

                materias.Add(materia);
            }
                conexaoComBanco.Close();

            return materias;
        }
    }
}