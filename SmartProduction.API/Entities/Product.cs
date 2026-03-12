using System.ComponentModel.DataAnnotations;

namespace SmartProduction.API.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public String Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public String SKU { get; set; } = string.Empty;
        public String Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}
