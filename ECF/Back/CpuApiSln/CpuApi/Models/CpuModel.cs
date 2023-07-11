using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CpuApi.Models
{
    [Table("cpus")]
    public class CpuModel
    {
        [Key]
        public int Id { get; set; }
    }
}
