using System.ComponentModel.DataAnnotations;

namespace SuperDesafioAdimaxBolada.Models;

public class Category
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O nome do produto é obrigatório")]
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdateAt { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}
