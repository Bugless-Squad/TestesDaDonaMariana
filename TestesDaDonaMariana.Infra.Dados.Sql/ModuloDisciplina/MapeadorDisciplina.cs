using System.Data.SqlClient;
using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloMateria;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloDisciplina
{
    public class MapeadorDisciplina : MapeadorBase<Disciplina>
    {
        public override void ConfigurarParametros(SqlCommand comando, Disciplina registro)
        {
            comando.Parameters.AddWithValue("@ID", registro.id);
            comando.Parameters.AddWithValue("@NOME", registro.nome);
        }

        public override Disciplina ConverterRegistro(SqlDataReader leitor)
        {
            if (leitor.HasColumn("DISCIPLINA_ID") == false)
                return null;

            int id = Convert.ToInt32(leitor["DISCIPLINA_ID"]);
            string nome = Convert.ToString(leitor["DISCIPLINA_NOME"]);

            List<Materia> materias = new RepositorioMateriaSql().SelecionarMateriasPorDisciplina(id);

            return new Disciplina(id, nome, materias);
        }

        public Disciplina ConverterRegistroId(SqlDataReader leitor)
        {
            if (leitor.HasColumn("DISCIPLINA_ID") == false)
                return null;

            int id = Convert.ToInt32(leitor["DISCIPLINA_ID"]);

            string nome = Convert.ToString(leitor["DISCIPLINA_NOME"]);

            return new Disciplina(id, nome);
        }
    }
}

