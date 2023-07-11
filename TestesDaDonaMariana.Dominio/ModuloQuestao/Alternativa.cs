namespace TestesDaDonaMariana.Dominio.ModuloQuestao
{
    public class Alternativa : EntidadeBase<Alternativa>
    {
        public string idLetra { get; set; } 
        public string texto { get; set; }
        public AlternativaCorretaEnum alternativaCorreta { get; set; }

        public Alternativa()
        {
            
        }

        public Alternativa(string texto)
        {
            this.texto = texto;
            alternativaCorreta = AlternativaCorretaEnum.Errada;
        }

        public Alternativa(int id, string idLetra, string texto, AlternativaCorretaEnum alternativaCorreta)
        {
            this.id = id;
            this.idLetra = idLetra;
            this.texto = texto;
            this.alternativaCorreta = alternativaCorreta;
        }

        public override string Validar()
        {
            Validador valida = new();

            if (valida.ValidaString(texto))
                return $"Você deve escrever uma alternativa!";

            return "";
        }

        public override string ToString()
        {
            return texto;
        }

        public override void AtualizarInformacoes(Alternativa registroAtualizado)
        {
            throw new NotImplementedException();
        }
    }
}
