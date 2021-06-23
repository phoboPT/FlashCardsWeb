using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Degree", Schema = "public")]
    public class Degree

    {
        [Key] public int key { get; set; }
        public int grade { get; set; }
        public string name { get; set; }
    }
}