using Domain.Models.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Ticket")
                .HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasConversion<string>();

            builder.Property(s => s.TicketNumber)
                .HasConversion<string>();

            builder.Property(s => s.CustomerId)
                .HasConversion<string>();

            builder.Property(s => s.UserId)
                .HasConversion<string>();





        }
    }
}
