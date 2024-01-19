using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication1.DataAccess.Models
{
    public class courses
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set;}

        [Required]
        public string CourseDescription { get;set; } 

        [Required]
        public string CourseCredit { get; set; }
    }
}
