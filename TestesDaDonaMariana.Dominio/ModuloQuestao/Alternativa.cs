namespace TestesDaDonaMariana.Dominio.ModuloQuestao
{
    public class Alternativa
    {
        public int id { get; set; }
        public int idContador { get; set; }
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

        public string Validar()
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
    }
}
