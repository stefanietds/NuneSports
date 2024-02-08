using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace NuneSports.Model;

[Table("Produtos")]
public class Produto
{
    [Key]
    public int Codigo_Produto { get; set; }
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [MaxLength(30, ErrorMessage = "O campo Nome deve ter no máximo 30 caracteres.")]
    [MinLength(3, ErrorMessage = "O campo Nome deve ter no minimo 3 caracteres.")]
    public string Nome_Produto { get; set; }
    [MaxLength(255, ErrorMessage = "O campo Nome deve ter no máximo 255 caracteres.")]
    public string Descricao_Produto { get; set; }
    [NotNull]
    public decimal Preco_Produto { get; set; }
}
