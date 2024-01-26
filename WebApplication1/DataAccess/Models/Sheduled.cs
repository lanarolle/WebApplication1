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
        public string StartTime { get;  set; }
        
        [Required]
        public string EndTime { get;  set;}

        [NotMapped]
        public string Day { get; set; }


    }
}
