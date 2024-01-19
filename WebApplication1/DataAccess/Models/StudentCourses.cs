using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication1.DataAccess.Models
{
    public class StudentCourses
    {
        [Key]
        public int StudentCoursesId { get; set; }

        
        public int StuRegId { get; set; }

        
        public int CourseId { get; set; }   
    }
}
