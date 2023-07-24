using System.Data.SqlClient;
using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloQuestao;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloDisciplina;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloQuestao;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloMateria
{
    public class MapeadorMateria : MapeadorBase<Materia>
    {
        public override void ConfigurarParametros(SqlCommand comando, Materia registro)
        {
            comando.Parameters.AddWithValue("@ID", registro.id);
            comando.Parameters.AddWithValue("@TITULO", registro.titulo);
            comando.Parameters.AddWithValue("@DISCIPLINA_ID", registro.disciplina.id);
            comando.Parameters.AddWithValue("@SERIE", registro.serie);
        }

        public override Materia ConverterRegistro(SqlDataReader leitor)
        {
            if (leitor.HasColumn("MATERIA_ID") == false)
                return null;

            int id = Convert.ToInt32(leitor["MATERIA_ID"]);
            string titulo = Convert.ToString(leitor["MATERIA_TITULO"]);
            Disciplina disciplina = new MapeadorDisciplina().ConverterRegistro(leitor);
            string serie = leitor["MATERIA_SERIE"].ToString();

            return new Materia(id, titulo, disciplina, serie);
        }
    }
}