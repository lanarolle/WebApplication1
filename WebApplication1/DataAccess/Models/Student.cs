using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication1.DataAccess.Models
{
    public class Student
    {
        [Key] 
        public int StuRegId { get; set; }

        [Required]
        public string StuName { get; set; }

        [Required]
        public string StuEmail { get; set; }

        
        public string StuMobNum { get; set; }

        public string DOB { get; set; }


        public string StuAddress { get; set; }

        [Required]
        public string Password { get; set; }
        public DateTime memberSince { get; internal set; }

        public bool userRole{ get; set; }



        // public int UserId { get; set; }




    }
}