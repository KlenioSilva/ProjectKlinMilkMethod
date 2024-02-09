using System.ComponentModel.DataAnnotations;

namespace AppRazorDevAIInAction.Models
{
    public class EstruturaEntityModel
    {
        public int Id { get; set; }
        public string? ChaveAcesso { get; set; }
        public string? ChaveEstrutura { get; set; }
        [Required]
        public string? Conteudo { get; set; }
        public string? Entidades {  get; set; }
        public string? MesAno { get; set; }
        public string? Tipo { get; set; }
    }
}
