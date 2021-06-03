using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{[Table("Course",Schema = "public")]
    public class Course
    
    {
        [Key]
        public int key { get; set; }
        public int grade { get; set; }
        public string name {get; set; }
    }
}