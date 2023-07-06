using System.Text.Json;
using System.Text.Json.Serialization;
using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloQuestao;
using TestesDaDonaMariana.Dominio.ModuloTeste;

namespace TestesDaDonaMariana.Infra.Dados.Json.Compartilhado
{
    public class ContextoDeDados
    {
        private const string NOME_ARQUIVO = "TestesDonaMariana.json";

        public List<Disciplina> disciplinas { get; set; }
        public List<Materia> materias { get; set; }
        public List<Questao> questoes { get; set; }
        public List<Teste> testes { get; set; }

        public ContextoDeDados()
        {
            disciplinas = new();
            materias = new();
            questoes = new();
            testes = new();
        }

        public ContextoDeDados(bool carregarDados) : this()
        {
            CarregarDoArquivoJson();
        }

        public void GravarEmArquivoJson()
        {
            if(!File.Exists(NOME_ARQUIVO))
                File.Create(NOME_ARQUIVO).Close();

            File.WriteAllText(NOME_ARQUIVO, JsonSerializer.Serialize(this, ObterConfiguracoes()));
        }

        private void CarregarDoArquivoJson()
        {
            if (File.Exists(NOME_ARQUIVO) && File.ReadAllText(NOME_ARQUIVO).Length > 0)
            {
                ContextoDeDados ctx = JsonSerializer.Deserialize<ContextoDeDados>(File.ReadAllText(NOME_ARQUIVO), ObterConfiguracoes());

                disciplinas = ctx.disciplinas;
                materias = ctx.materias;
                questoes = ctx.questoes;
                testes = ctx.testes;
            }
        }

        private static JsonSerializerOptions ObterConfiguracoes()
        {
            JsonSerializerOptions opcoes = new();
            opcoes.IncludeFields = true;
            opcoes.WriteIndented = true;
            opcoes.ReferenceHandler = ReferenceHandler.Preserve;

            return opcoes;
        }
    }
}
