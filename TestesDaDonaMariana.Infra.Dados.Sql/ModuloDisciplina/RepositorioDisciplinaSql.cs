using Microsoft.Win32;
using System.Data.SqlClient;
using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloTeste;
using TestesDaDonaMariana.Infra.Dados.Sql.Compartilhado;

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

        public void Editar(Disciplina registroSelecionado, Disciplina registroAtualizado)
        {
            throw new NotImplementedException();
        }

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
    }
}