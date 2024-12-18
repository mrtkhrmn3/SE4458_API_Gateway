using Microsoft.EntityFrameworkCore;
using TicketService.Model;

namespace TicketService.Context
{
    public class TicketDbContext : DbContext
    {

        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options)
        {
            
        }

        public DbSet<Ticket> Tickets { get; set; }
    }
}
