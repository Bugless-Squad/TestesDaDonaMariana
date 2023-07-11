namespace TestesDaDonaMariana.Dominio.ModuloQuestao
{
    public class Alternativa : EntidadeBase<Alternativa>
    {
        public string idLetra { get; set; } 
        public string texto { get; set; }
        public string alternativaCorreta { get; set; }

        public Alternativa()
        {
            
        }

        public Alternativa(string texto)
        {            
            this.texto = texto;
            alternativaCorreta = "Errada";
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
