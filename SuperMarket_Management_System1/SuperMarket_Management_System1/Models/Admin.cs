using System.ComponentModel.DataAnnotations;

namespace SuperMarket_Management_System1.Models
{
    public class Admin
    {
        public string Id { get; set; }

        [StringLength(10, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
