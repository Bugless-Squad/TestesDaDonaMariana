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
            comando.Parameters.AddWithValue("@ENUNCIADO", registro.enunciado);
            comando.Parameters.AddWithValue("@DISCIPLINA_ID", registro.disciplina.id);
            comando.Parameters.AddWithValue("@MATERIA_ID", registro.materia.id);
            comando.Parameters.AddWithValue("@ALTERNATIVACORRETA_ID", registro.alternativaCorreta?.id);
        }

        public override Questao ConverterRegistro(SqlDataReader leitor)
        {
            int id = Convert.ToInt32(leitor["ID"]);
            string enunciado = Convert.ToString(leitor["ENUNCIADO"]);
            int disciplinaId = Convert.ToInt32(leitor["DISCIPLINA_ID"]);
            int materiaId = Convert.ToInt32(leitor["MATERIA_ID"]);
            int? alternativaCorretaId = leitor["ALTERNATIVACORRETA_ID"] != DBNull.Value ? Convert.ToInt32(leitor["ALTERNATIVACORRETA_ID"]) : null;

            Disciplina disciplina = new RepositorioDisciplinaSql().SelecionarPorId(disciplinaId);
            Materia materia = new RepositorioMateriaSql().SelecionarPorId(materiaId);
            Alternativa alternativaCorreta = alternativaCorretaId.HasValue ? new RepositorioAlternativaSql().SelecionarPorId(alternativaCorretaId.Value) : null;

            Questao questao = new(id, enunciado, disciplina, materia);
            questao.alternativaCorreta = alternativaCorreta;

            return questao;
        }

        public List<Questao> SelecionarQuestoesPorTeste(int testeId)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarPorTeste = conexaoComBanco.CreateCommand();
            comandoSelecionarPorTeste.CommandText = @"SELECT 
                                                    Q.[id] AS ID,
                                                    Q.[enunciado] AS ENUNCIADO,
                                                    Q.[disciplina_id] AS DISCIPLINA_ID,
                                                    Q.[materia_id] AS MATERIA_ID,
                                                    Q.[alternativaCorreta_id] AS ALTERNATIVACORRETA_ID
                                                  FROM 
                                                    [TBQUESTAO] AS Q
                                                  INNER JOIN [TBTESTE_QUESTAO] AS TQ
                                                      ON Q.[id] = TQ.[questao_id]
                                                  WHERE 
                                                    TQ.[teste_id] = @TESTE_ID;";

            comandoSelecionarPorTeste.Parameters.AddWithValue("@TESTE_ID", testeId);

            SqlDataReader leitorQuestoes = comandoSelecionarPorTeste.ExecuteReader();

            List<Questao> questoes = new List<Questao>();

            while (leitorQuestoes.Read())
            {
                Questao questao = ConverterRegistro(leitorQuestoes);
                questoes.Add(questao);
            }

            conexaoComBanco.Close();

            return questoes;
        }
    }
}
