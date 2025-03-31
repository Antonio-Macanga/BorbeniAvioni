using Beckend.Models;

namespace Backend.Models
{
    public class Proizvodaci : Entitet
    {
        public string Naziv { get; set; } = "";
        public string Drzava { get; set; } = "";
        public DateTime DatumOsnivanja { get; set; }
    }
}
