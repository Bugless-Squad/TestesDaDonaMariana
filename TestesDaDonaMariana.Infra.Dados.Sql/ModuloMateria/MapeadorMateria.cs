using System.Data.SqlClient;
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

        public override Materia ConverterRegistro(SqlDataReader leitorRegistros)
        {
            //int id = Convert.ToInt32(leitorRegistros["MATERIA_ID"]);
            //string nome = Convert.ToString(leitorRegistros["MATERIA_NOME"]);
            //OpcoesSeriesEnum serie = Convert.ToString(leitorRegistros["MATERIA_SERIE"]);

            //Disciplina disciplina = new MapeadorDisciplina().ConverterRegistro(leitorRegistros);

            //return new Materia(id, nome, disciplina, serie);

            return new();
        }

    }
}