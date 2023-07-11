using System.Data.SqlClient;
using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloDisciplina;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloMateria
{
    public class MapeadorMateria : MapeadorBase<Materia>
    {
        protected string enderecoBanco =
             @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=TestesDonaMarianaBD;Integrated Security=True";

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

        public Materia ConverterRegistroComDisciplina(SqlDataReader leitor)
        {
            int id = Convert.ToInt32(leitor["MATERIA_ID"]);
            string nome = Convert.ToString(leitor["MATERIA_NOME"]);
            string serie = leitor["MATERIA_SERIE"].ToString();

            Disciplina disciplina = new MapeadorDisciplina().ConverterRegistroId(leitor);

            return new Materia(id, nome, disciplina, serie);
        }

        public List<Materia> SelecionarMateriasPorTeste(int testeId)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarPorTeste = conexaoComBanco.CreateCommand();
            comandoSelecionarPorTeste.CommandText = @"SELECT 
                                                    M.[id] AS MATERIA_ID,
                                                    M.[nome] AS MATERIA_NOME,
                                                    M.[disciplina_id] AS DISCIPLINA_ID,
                                                    M.[serie] AS MATERIA_SERIE
                                                  FROM 
                                                    [TBMATERIA] AS M
                                                  INNER JOIN [TBMATERIA_TESTE] AS MT
                                                      ON M.[id] = MT.[materia_id]
                                                  WHERE 
                                                    MT.[teste_id] = @TESTE_ID";

            comandoSelecionarPorTeste.Parameters.AddWithValue("@TESTE_ID", testeId);

            SqlDataReader leitorMaterias = comandoSelecionarPorTeste.ExecuteReader();

            List<Materia> materias = new List<Materia>();
            MapeadorMateria mapeador = new MapeadorMateria();

            while (leitorMaterias.Read())
            {
                Materia materia = mapeador.ConverterRegistro(leitorMaterias);
                materias.Add(materia);
            }

            conexaoComBanco.Close();

            return materias;
        }
    }
}