using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("AnswerType",Schema = "public")]
    public class AnswerType
    {
        [Key]
        public int key { get; set; }
        public string name {get; set; }
       
    }
}