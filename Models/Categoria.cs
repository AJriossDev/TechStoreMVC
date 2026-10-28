namespace TechStoreMVC.Models
{                                                                                   
    public class Categoria
    {
        // Propriedades
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        // public bool Ativa { get; set; }
        
        public Categoria()
        {
            
        }
        // Construtor com parâmetros
        public Categoria(int id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }
    }
}