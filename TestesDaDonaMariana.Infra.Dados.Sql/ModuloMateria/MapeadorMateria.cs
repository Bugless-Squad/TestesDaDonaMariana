using System.Data.SqlClient;
using System.Numerics;
using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Infra.Dados.Sql.Compartilhado;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloDisciplina;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloMateria
{
    public class MapeadorMateria : MapeadorBase<Materia>
    {
        public override void ConfigurarParametros(SqlCommand comando, Materia registro)
        {
            comando.Parameters.AddWithValue("@ID", registro.id);
            comando.Parameters.AddWithValue("@NOME", registro.titulo);
            comando.Parameters.AddWithValue("@DISCIPLINA_ID", registro.disciplina.id);
            comando.Parameters.AddWithValue("@SERIE", registro.serie);
        }

        public override Materia ConverterRegistro(SqlDataReader leitor)
        {
            int id = Convert.ToInt32(leitor["MATERIA_ID"]);

            string nome = Convert.ToString(leitor["MATERIA_NOME"]);

            string serie = leitor["MATERIA_SERIE"].ToString();

            Disciplina disciplina = new MapeadorDisciplina().ConverterRegistro(leitor);

            return new Materia(id, nome, disciplina, serie);
        }
    }
}