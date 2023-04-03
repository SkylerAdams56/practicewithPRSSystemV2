using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace practicewithPRSSystemV2.Models
{
    public class Requestlines
    {
        public int Id { get; set; }
        [ForeignKey("RequestId")]
        public int RequestId { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [JsonIgnore]
        public virtual Requests Request { get; set; }
        public virtual Products Product { get; set; }
        public Requestlines() { }
    }
}
