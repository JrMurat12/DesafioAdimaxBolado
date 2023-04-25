namespace SuperDesafioAdimaxBolada.Data.DTOs;

public class ReadCategoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<ReadProductCategoryDTO> ProductsCategories { get; set; }
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}
