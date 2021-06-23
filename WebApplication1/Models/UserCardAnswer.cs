using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("UserCardAnswer", Schema = "public")]
    public class UserCardAnswer
    {
        [Key] public int key { get; set; }

        public int card { get; set; }

        public int user { get; set; }

        public int type { get; set; }
        public DateTime date { get; set; }
    }
}