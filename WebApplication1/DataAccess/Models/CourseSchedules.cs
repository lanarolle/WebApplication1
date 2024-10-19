using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.DataAccess.Models
{
    public class CourseSchedules
    {

        [Key]
        public int CourseSchedulesID { get; set; }

        [ForeignKey("SheduledId")]

        public int SheduledId { get; set; }


        [ForeignKey("CourseName")]
        public string CourseName { get; set; }

        [JsonIgnore]
        public courses Course { get; set; }

        [JsonIgnore]
        public  Sheduled Sheduled  { get; set; }
    }

    


}
