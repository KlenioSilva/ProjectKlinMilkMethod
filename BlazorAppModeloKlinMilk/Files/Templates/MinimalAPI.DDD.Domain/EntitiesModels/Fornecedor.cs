using System.ComponentModel.DataAnnotations;

namespace MinimalAPI.DDD.Domain.EntitiesModels
{
    public class Fornecedor
    {
        public int Id { get; set; }
        [MaxLength(200, ErrorMessage = "Informe um nome com no máximo 200 caracteres.")]
        [MinLength(10, ErrorMessage = "Informe um nome com no mínimo 10 caracteres")]
        public string? Nome { get; set; }
        [MaxLength(14, ErrorMessage = "Informe um nome com no máximo 14 caracteres.")]
        [MinLength(11, ErrorMessage = "Informe um nome com no mínimo 11 caracteres")]
        public string? Documento { get; set; }
        public bool Ativo { get; set; }
    }
}