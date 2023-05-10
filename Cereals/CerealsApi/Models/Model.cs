using System.ComponentModel.DataAnnotations;

namespace CerealsApi.Models
{
    public abstract class Model
    {
       public int Id { get; set; }
       public abstract void UpdateFromModel(Model value); 
    }
}
