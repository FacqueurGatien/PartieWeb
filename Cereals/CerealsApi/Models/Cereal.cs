using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using CerealsApi;
using System.Collections;
using System;

namespace CerealsApi.Models
{
    [Table("TBL_Cereals")]
    public class Cereal : Model
    {
        [Required]
        [Column("cerealName")]
        public string Name { get; set; }
        [Required]
        [Column("cerealCalorie")]
        public int Calories { get; set; }
        [Required]
        [Column("cerealProtein")]
        public int Protein { get; set; }

        public override void UpdateFromModel(Model value)
        {
            Cereal tt = value as Cereal;
            this.Name = tt.Name;
            this.Protein = tt.Protein;
            this.Calories = tt.Calories;
        }
    }
}
