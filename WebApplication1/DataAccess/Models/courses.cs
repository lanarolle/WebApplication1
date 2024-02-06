using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json.Serialization;

namespace WebApplication1.DataAccess.Models
{
    public class courses
    {
        //internal object CourseSchedules;

        // internal readonly object CourseSchedules;


        [Key]
        public string CourseName { get; set;}

        [Required]
        public string CourseDescription { get;set; } 

        [Required]
        public string CourseCredit { get; set; }


        [JsonIgnore]
        public ICollection<CourseSchedules>? CourseSchedules { get; set; }
    }
}
