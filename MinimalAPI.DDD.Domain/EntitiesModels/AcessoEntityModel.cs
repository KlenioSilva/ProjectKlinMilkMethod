using System.Text.Json.Serialization;

namespace MetodoKlinMilk.Domain.Entities
{
    public class AcessoEntityModel
    {
        public int Id { get; set; }
        public string? Logon { get; set; }
        public string? Chave { get; set;}
        public string? IP { get; set; }
        public string? Email { get; set; }
        public bool Autorizado { get; set; }
        public Int16 Dias { get; set;}
        public DateTime DataExpiracao {  get; set;}
    }
}
