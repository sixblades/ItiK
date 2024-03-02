using Dominio.Models.Shared;
using Dominio.Models.Store;
using Dominio.Models.Tickets;
using Dominio.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }  
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Address> Addresses { get; set; }   
        public DbSet<TicketItem> Items { get; set; }
        public DbSet<Store> Commerces { get; set; }

    }
}
