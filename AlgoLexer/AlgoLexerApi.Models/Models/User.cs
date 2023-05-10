using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLexerApi.Models.Models
{
    [Table("Users")]
    public class User : Model
    {
        [Required]
        [Column("UserUserName")]
        [StringLength(maximumLength: 16, MinimumLength = 3)]
        /*        [RegularExpression(@"^[\p{L}]{2,}(?:[-]{0,1}[\p{L}]{2,}){0,1}$")]*/
        [RegularExpression(@"^[a-zA-Z]+(?:\-[a-zA-Z]+)?$")]
        public string? UserName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]{8,}$")]
        [Column("UserPassword")]
        public string? Password { get; set; }
    }
}
