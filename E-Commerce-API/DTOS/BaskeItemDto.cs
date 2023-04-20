using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.DTOS
{
    public class BaskeItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        [Range(1, double.MaxValue,ErrorMessage ="Price must be greater than zero.")]
        public double Price { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Qty at least be one.")]
        public int Qty { get; set; }
    }
}
