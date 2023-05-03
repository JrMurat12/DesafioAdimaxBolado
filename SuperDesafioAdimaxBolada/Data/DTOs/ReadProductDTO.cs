using System.ComponentModel.DataAnnotations;

namespace SuperDesafioAdimaxBolada.Data.DTOs;

public class ReadProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public ICollection<ReadProductCategoryDTO> ProductsCategories { get; set; }
    public bool? HasPendingLogUpdate { get; set; }
}
