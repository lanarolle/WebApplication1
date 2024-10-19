using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.DataAccess.Models
{
   // course code, start time, end time, day
    public class Sheduled
    {
        [Key]
        public int SheduledId { get; set; }

        [ForeignKey("CourseName")]
        public string CourseName { get; set; }
        
        [Required]
        public string StartTime { get;  set; }
        
        [Required]
        public string EndTime { get;  set;}

        [Required]
        public string Day { get; set; }
 
        [JsonIgnore]
        public ICollection<CourseSchedules>? CourseSchedules { get; set;}
        
    }
}
 