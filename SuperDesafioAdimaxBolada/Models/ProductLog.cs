namespace SuperDesafioAdimaxBolada.Models;

public class ProductLog
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string ProductJson { get; set; }
}
