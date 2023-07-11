using System.Data.SqlClient;
using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloQuestao;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloDisciplina;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloMateria;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloQuestao
{
    public class MapeadorQuestao : MapeadorBase<Questao>
    {
        protected string enderecoBanco =
             @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=TestesDonaMarianaBD;Integrated Security=True";
        public override void ConfigurarParametros(SqlCommand comando, Questao registro)
        {
            comando.Parameters.AddWithValue("@ID", registro.id);
            comando.Parameters.AddWithValue("@DISCIPLINA_ID", registro.disciplina.id);
            comando.Parameters.AddWithValue("@MATERIA_ID", registro.materia.id);
            comando.Parameters.AddWithValue("@ENUNCIADO", registro.enunciado);
        }

        public override Questao ConverterRegistro(SqlDataReader leitor)
        {
            int id = Convert.ToInt32(leitor["QUESTAO_ID"]);
            string enunciado = Convert.ToString(leitor["QUESTAO_ENUNCIADO"]);

            Disciplina disciplina = new MapeadorDisciplina().ConverterRegistro(leitor);
            Materia materia = new MapeadorMateria().ConverterRegistro(leitor);

            Questao questao = new Questao();
            questao.id = id;
            questao.enunciado = enunciado;
            questao.disciplina = disciplina;
            questao.materia = materia;

            return questao;
        }

        public List<Questao> SelecionarQuestoesPorTeste(int testeId)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarPorTeste = conexaoComBanco.CreateCommand();
            comandoSelecionarPorTeste.CommandText = @"SELECT 
                                                    Q.[id] AS QUESTAO_ID,
                                                    Q.[enunciado] AS QUESTAO_ENUNCIADO,
                                                    Q.[disciplina_id] AS DISCIPLINA_ID,
                                                    Q.[materia_id] AS MATERIA_ID
                                                  FROM 
                                                    [TBQUESTAO] AS Q
                                                  INNER JOIN [TBQUESTAO_TESTE] AS QT
                                                      ON Q.[id] = QT.[questao_id]
                                                  WHERE 
                                                    QT.[teste_id] = @TESTE_ID";

            comandoSelecionarPorTeste.Parameters.AddWithValue("@TESTE_ID", testeId);

            SqlDataReader leitorQuestoes = comandoSelecionarPorTeste.ExecuteReader();

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
