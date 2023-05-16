using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLexerApi.Models.Models
{
    public class UserChangePassword : User
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]{8,}$")]
        [Column("UserPassword")]
        public string NewPassword { get; set; }
    }
}
