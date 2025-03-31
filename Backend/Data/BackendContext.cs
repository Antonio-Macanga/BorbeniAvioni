using Beckend.Models;
using Microsoft.EntityFrameworkCore;

namespace Beckend.Data
{
    public class BackendContext : DbContext
    {

        public BackendContext(DbContextOptions<BackendContext> opcije) : base(opcije)
        {
            //ovdje se  mogu fino postaviti opcije, ali ne za sada
        }


        public DbSet<Drzava> Drzave { get; set; } // zbog ovog ovdje Smjerovi se tablica zove u mnozini

    }
}
