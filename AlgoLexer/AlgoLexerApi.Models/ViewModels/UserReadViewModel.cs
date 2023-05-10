using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLexerApi.Models.ViewModels
{
    public class UserReadViewModel : Models.Model
    {
        [Required]
        [Column("UserUserName")]
        [StringLength(maximumLength: 16, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]+(?:\-[a-zA-Z]+)?$")]
        public string? UserName { get; set; }
    }
}
