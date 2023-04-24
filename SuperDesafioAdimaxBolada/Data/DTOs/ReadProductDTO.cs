using System.ComponentModel.DataAnnotations;

namespace SuperDesafioAdimaxBolada.Data.DTOs;

public class ReadProductDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public ICollection<ReadProductCategoryDTO> ProductsCategories { get; set; }
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}
