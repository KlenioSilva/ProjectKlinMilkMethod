using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorAppModeloKlinMilk.Models
{
    public class AcessoEntityModel
    {
        public int Id { get; set; }
        [Required]
        public string? Logon { get; set; }
        public string? Chave { get; set;}
        public string? IP { get; set; }
        [Required]
        public string? Email { get; set; }
        public bool Autorizado { get; set; }
        public Int16 Dias { get; set;}
        public Int16 TipoPlano { get; set; }
        public DateTime DataExpiracao {  get; set;}
    }
}
