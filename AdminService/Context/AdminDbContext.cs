using AdminService.Model;
using Microsoft.EntityFrameworkCore;

namespace AdminService.Context
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions <AdminDbContext> options) : base(options)
        {
            
        }
        public DbSet<Admin> Admins { get; set; }
    }
}
