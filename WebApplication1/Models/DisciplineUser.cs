using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("DisciplineUser",Schema = "public")]
    public class DisciplineUser
    {
        [Key]
        public int key { get; set; }
        public int discipline {get; set; }
        public int user { get; set; }
    }
}