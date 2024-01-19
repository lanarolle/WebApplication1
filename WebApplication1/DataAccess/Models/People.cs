using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DataAccess.Models
{
    public class People
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string StuEmail { get; set; }

        [Required]
        public string Password { get; set; }

        public Student Student { get; set; }
    }
}
