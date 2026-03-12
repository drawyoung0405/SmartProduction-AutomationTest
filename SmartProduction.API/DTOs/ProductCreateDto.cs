using System.ComponentModel.DataAnnotations;

namespace SmartProduction.API.DTOs
{
    public class ProductCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string SKU { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
