using System.ComponentModel.DataAnnotations;

namespace Beckend.Models
{
    public abstract class Entitet
    {
        [Key]
        public int Sifra { get; set; }
    }
}
