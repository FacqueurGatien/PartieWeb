using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CerealsApi.Models
{
    [Table("TBL_Cereals")]
    public class Cereal
    {
        [Key]
        [Column("cerealId")]
        public int CerealId { get; set; }
        [Required]
        [Column("cerealName")]
        public string Name { get; set; }
        [Required]
        [Column("cerealCalorie")]
        public int Calories { get; set; }
        [Required]
        [Column("cerealProtein")]
        public int Protein { get; set; }
    }
}
