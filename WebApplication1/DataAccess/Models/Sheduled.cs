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

        [Required]
       public courses CourseName { get; set; }
        
        [Required]
        public string StartTime { get;  set; }
        
        [Required]
        public string EndTime { get;  set;}

        [Required]
        public string Day { get; set; }


        
        [JsonIgnore]
        public ICollection<CourseSchedules>? CourseSchedules { get; set; }
        public string Coursecode { get;  set; }
        // public string  CourseName1 { get; set; }
        // public virtual string CourseName1 { get; set; }
        //public object CourseSchedules { get; internal set; }
    }
}
 