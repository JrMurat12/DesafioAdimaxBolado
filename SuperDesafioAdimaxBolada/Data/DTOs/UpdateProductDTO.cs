using System.ComponentModel.DataAnnotations;

namespace SuperDesafioAdimaxBolada.Data.DTOs;

public class UpdateProductDTO
{
    [Required(ErrorMessage = "O nome do produto é obrigatório")]
    public string Name { get; set; }
    [Required(ErrorMessage = "A descrição é obrigatória")]
    public string Description { get; set; }
    [Required]
    public int Price { get; set; }
    public int CategoryId { get; set; }
}
