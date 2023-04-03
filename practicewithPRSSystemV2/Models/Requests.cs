using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practicewithPRSSystemV2.Models
{
    public class Requests
    {
        public Requests() { }
        public int Id { get; set; }
        [StringLength(80)]
        public string Description { get; set; }
        [StringLength(80)]
        public string Justification { get; set; }
        [StringLength(80)]
        public string RejectionReason { get; set; }
        [StringLength(20)]
        public string DeliveryMode { get; set; }
        [StringLength(10)]
        public string Status { get; set; }
        [Column(TypeName = "decimal (11,2)")]
        public decimal Total { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual Users User { get; set; }
    }
}
