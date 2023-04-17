using System.ComponentModel.DataAnnotations;

namespace SuperDesafioAdimaxBolada.Data.DTOs
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        public string Name { get; set; }
    }
}
