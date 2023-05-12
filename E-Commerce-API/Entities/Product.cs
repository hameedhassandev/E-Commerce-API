using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.Entities
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public ProductType ProductType { get; set; }
        [Required]
        public int ProductTypeId { get; set; }

        public ProductBrand ProductBrand { get; set; }
        [Required]
        public int ProductBrandId { get; set; }
    }
}
