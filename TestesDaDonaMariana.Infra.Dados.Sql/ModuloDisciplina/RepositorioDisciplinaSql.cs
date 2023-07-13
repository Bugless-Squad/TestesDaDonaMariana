using System.Data.SqlClient;
using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloMateria;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloDisciplina
{
    public class RepositorioDisciplinaSql : RepositorioBaseSql<Disciplina, MapeadorDisciplina>, IRepositorioDisciplina
    {
        protected override string sqlInserir => @"INSERT INTO [TBDISCIPLINA] 
	                                            (
		                                            [NOME]
	                                            )
	                                            VALUES 
	                                            (
		                                            @NOME
	                                            );                 

                                            SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar => @"UPDATE [TBDISCIPLINA] 
                                                SET
                                                    [NOME] = @NOME
                                                WHERE
                                                    [ID] = @ID";

        protected override string sqlExcluir => @"DELETE FROM [TBDISCIPLINA]
	                                                WHERE 
		                                                [ID] = @ID";

        protected override string sqlSelecionarTodos => @"SELECT 
	                                                    [ID]        DISCIPLINA_ID 
	                                                   ,[NOME]      DISCIPLINA_NOME
                                                    FROM 
	                                                    [TBDISCIPLINA]";

        protected override string sqlSelecionarPorId => @"SELECT 
	                                                    [ID]        DISCIPLINA_ID 
	                                                   ,[NOME]      DISCIPLINA_NOME
                                                    FROM 
	                                                    [TBDISCIPLINA] 
                                                    WHERE 
                                                        [ID] = @ID";

        public Disciplina SelecionarPorId(int id)
        {
            Disciplina disciplina = base.SelecionarPorId(id);

            return disciplina;
        }

        public List<Disciplina> SelecionarTodos()
        {
            List<Disciplina> disciplinas = base.SelecionarTodos();

            return disciplinas;
        }
        public List<Materia> SelecionarMateriasPorDisciplina(int disciplinaId)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarMaterias = conexaoComBanco.CreateCommand();
            comandoSelecionarMaterias.CommandText = @"SELECT [ID] MATERIA_ID,
                                                         [NOME] MATERIA_NOME,
                                                         [SERIE] MATERIA_SERIE,
                                                         [DISCIPLINA_ID]
                                                  FROM [TBMATERIA]
                                                  WHERE [DISCIPLINA_ID] = @DISCIPLINA_ID";

            comandoSelecionarMaterias.Parameters.AddWithValue("@DISCIPLINA_ID", disciplinaId);

            SqlDataReader leitorMaterias = comandoSelecionarMaterias.ExecuteReader();

            List<Materia> materias = new List<Materia>();

            MapeadorMateria mapeadorMateria = new MapeadorMateria();

            while (leitorMaterias.Read())
            {
                Materia materia = mapeadorMateria.ConverterRegistro(leitorMaterias);
                materias.Add(materia);
            }

            conexaoComBanco.Close();

            return materias;
        }
    }
}