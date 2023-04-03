using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace practicewithPRSSystemV2.Models
{
    [Index("Username", IsUnique=true)]
    public class Users
    {
        public Users() { }
        public int Id { get; set; }
        [StringLength(30)]
        public string Username { get; set; }
        [StringLength(30)]
        public string Password { get; set; }
        [StringLength(30)]
        public string Firstname { get; set; }
        [StringLength(30)]
        public string Lastname { get; set; }
        [StringLength(12)]
        public string? Phone { get; set; }
        [StringLength(255)]
        public string? Email { get; set; }
        public bool IsReviewer { get; set; }
        public bool IsAdmin { get; set; }

    }
}
