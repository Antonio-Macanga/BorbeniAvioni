namespace Backend.Models
{
    public class Avion : Entitet
    {
        public string Naziv { get; set; } = "";
        public int Proizvodac { get; set; } // Strani ključ prema tablici Proizvodaci
        public string Klasa { get; set; } = "";
        public DateTime DatumPrvogLeta { get; set; } 
        public string? Model { get; set; }
        public bool? Export { get; set; }
    }
}
    namespace Backend.Models
    {
        public class Entitet
        {
            public int Id { get; set; }
        }
    }
