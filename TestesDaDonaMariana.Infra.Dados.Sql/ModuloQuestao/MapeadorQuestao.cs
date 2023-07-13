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


        public override void ConfigurarParametros(SqlCommand comando, Questao questao)
        {
            comando.Parameters.AddWithValue("@ID", questao.id);
            comando.Parameters.AddWithValue("@ENUNCIADO", questao.enunciado);
            comando.Parameters.AddWithValue("@DISCIPLINA_ID", questao.disciplina.id);
            comando.Parameters.AddWithValue("@MATERIA_ID", questao.materia.id);
            comando.Parameters.AddWithValue("@ALTERNATIVACORRETA_ID", questao.alternativaCorreta?.id);
        }

        public override Questao ConverterRegistro(SqlDataReader leitor)
        {
            int id = Convert.ToInt32(leitor["ID"]);
            string enunciado = Convert.ToString(leitor["ENUNCIADO"]);
            int disciplinaId = Convert.ToInt32(leitor["DISCIPLINA_ID"]);
            int materiaId = Convert.ToInt32(leitor["MATERIA_ID"]);
            int? alternativaCorretaId = leitor["ALTERNATIVACORRETA_ID"] as int?;

            Disciplina disciplina = new RepositorioDisciplinaSql().SelecionarPorId(disciplinaId);
            Materia materia = new RepositorioMateriaSql().SelecionarPorId(materiaId);
            Alternativa alternativaCorreta = alternativaCorretaId.HasValue ? new RepositorioAlternativaSql().SelecionarPorId(alternativaCorretaId.Value) : null;

            return new Questao(id, enunciado, disciplina, materia, alternativaCorreta);
        }

        //public override Questao ConverterRegistro(SqlDataReader leitor)
        //{
        //    int id = Convert.ToInt32(leitor["QUESTAO_ID"]);
        //    string enunciado = Convert.ToString(leitor["ENUNCIADO"]);

        //    Disciplina disciplina = new MapeadorDisciplina().ConverterRegistro(leitor);
        //    Materia materia = new MapeadorMateria().ConverterRegistro(leitor);

        //    int? alternativaCorretaId = leitor["ALTERNATIVACORRETA_ID"] != DBNull.Value ? Convert.ToInt32(leitor["ALTERNATIVACORRETA_ID"]) : (int?)null;
        //    Alternativa alternativaCorreta = null;

        //    if (alternativaCorretaId != null)
        //    {
        //        alternativaCorreta = new MapeadorAlternativa().SelecionarPorId(alternativaCorretaId.Value);
        //    }

        //    List<Alternativa> alternativas = new RepositorioAlternativaSql().SelecionarAlternativasPorQuestao(id);

        //    Questao questao = new Questao(id, enunciado, disciplina, materia, alternativas);
        //    questao.alternativaCorreta = alternativaCorreta;

        //    return questao;
        //}

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
