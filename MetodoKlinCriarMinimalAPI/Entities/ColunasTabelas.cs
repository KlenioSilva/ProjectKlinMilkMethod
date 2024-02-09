namespace MetodoKlinCriarMinimalAPI.Entities
{
    public class ColunasTabelas
    {
        public long Id { get; set; }
        public string? Tabela { get; set; }
        public string? Coluna { get; set; }    
        public string? Tipo { get; set; }
        public bool JsonIgnore { get;}
    }
}
