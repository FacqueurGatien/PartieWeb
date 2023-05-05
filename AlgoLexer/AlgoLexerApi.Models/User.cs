using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLexerApi.Models
{
    [Table("Users")]
    internal class User : Model
    {
        [Required]
        [Column("UserUserName")]
        [MaxLength(16)]
        public string? UserName { get; set; }
        [Required]
        [Column("UserPassword")]
        public string? Password { get; set; }
    }
}
