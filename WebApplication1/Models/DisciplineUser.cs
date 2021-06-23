using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("DisciplineUser", Schema = "public")]
    public class DisciplineUser
    {
        [Key] public int key { get; set; }
        public int disciplineKey { get; set; }

        public int userkey { get; set; }
        [NotMapped] public string name { get; set; }
    }
}