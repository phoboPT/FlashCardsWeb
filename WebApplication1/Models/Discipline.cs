using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Discipline", Schema = "public")]
    public class Discipline
    {
        [Key] public int key { get; set; }
        public string name { get; set; }
        public int degree { get; set; }
    }
}