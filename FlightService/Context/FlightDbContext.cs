using FlightService.Model;
using Microsoft.EntityFrameworkCore;

namespace FlightService.Context
{
    public class FlightDbContext : DbContext
    {
        public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options)
        {
            
        }

        public DbSet<Flight> Flights { get; set; }
    }
}
