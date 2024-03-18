using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Models
{
    public class Order
    {
        [Key]
        [Required]
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [DisplayFormat(NullDisplayText = "No status")]
        public string? Status { get; set; }

        public ICollection<OrderDetails>? OrderDetails { get; set; }
    }
}
