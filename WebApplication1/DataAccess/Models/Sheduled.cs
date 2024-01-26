using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace WebApplication1.DataAccess.Models
{
   // course code, start time, end time, day
    public class Sheduled
    {
        [Key]
        public string SheduledId { get; set; }

        [Required]
        public courses CourseName { get; set; }
        
        [Required]
        public DateTime StartTime { get;  set; }
        
        [Required]
        public DateTime EndTime { get;  set;}

        [NotMapped]
        public DateOnly Day { get; set; }


    }
}
