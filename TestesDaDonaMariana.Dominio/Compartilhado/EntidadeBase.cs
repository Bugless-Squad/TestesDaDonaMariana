namespace TestesDaDonaMariana.Dominio.Compartilhado
{
    [Serializable]
    public abstract class EntidadeBase<T>
    {
        public int id { get; set; }

        public abstract void AtualizarInformacoes(T registroAtualizado);

        public abstract string Validar();
    }
}
