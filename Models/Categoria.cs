namespace TechStoreMVC.Models
{
    public class Categoria
    {
        // Propriedades
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public bool Ativa { get; set; }

        // Construtor com parâmetros
        public Categoria(int id, string nome, string descricao, bool ativa)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Ativa = ativa;
        }
    }
}