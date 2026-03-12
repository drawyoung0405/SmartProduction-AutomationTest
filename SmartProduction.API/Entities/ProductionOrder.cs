using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartProduction.API.Entities
{
    public enum OrderStatus
    {
        Pending = 0,
        InProgress = 1,
        Completed = 2,
        Defective = 3
    }
    public class ProductionOrder
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public String OrderNumber { get; set; } = string.Empty;

        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; } = null!;
        [Required]
        public int Quantity { get; set; }
        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public DateTime? CompletionDate { get; set; } = null;

    }
}
