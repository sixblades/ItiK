using Dominio.Models.Shared;
using Dominio.Models.Store;
using Dominio.Models.Tickets;
using Dominio.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Interfaces
{
    public interface IApplicationDbContex
    {
        DbSet<User> Users { get; set; }
        DbSet<Ticket> Tickets { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<TicketItem> Items { get; set; }
        DbSet<Store> Commerces { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
