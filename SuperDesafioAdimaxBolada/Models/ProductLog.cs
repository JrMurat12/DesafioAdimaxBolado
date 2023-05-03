using System.ComponentModel.DataAnnotations;

namespace SuperDesafioAdimaxBolada.Models;

public class ProductLog
{
    [Key]
    [Required]
    public int Id { get; set; }
    public int ProductId { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string ProductJson { get; set; }


}
