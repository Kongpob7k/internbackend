using Microsoft.EntityFrameworkCore;
using RepairRequestApi.Models;
    
namespace RepairRequestApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();

        public DbSet<RepairTicket> RepairTickets => Set<RepairTicket>();
    }
}
