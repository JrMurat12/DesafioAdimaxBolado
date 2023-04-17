using System.ComponentModel.DataAnnotations;

namespace SuperDesafioAdimaxBolada.Models;

public class Product
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O nome do produto é obrigatório")]
    public string Name { get; set; }
    [Required(ErrorMessage = "A descrição é obrigatória")]
    public string Description { get; set; }
    [Required(ErrorMessage = "O preço é obrigatório")]
    public int Price { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string? HasPendingLogUpdate { get; set; }

}
