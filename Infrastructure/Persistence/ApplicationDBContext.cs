using Application.Data;
using Domain.Models.User;
using Domain.Primitives;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext, IApplicationDbContext, IUnitOfWork
    {
        private IPublisher _publisher;

        public ApplicationDBContext(DbContextOptions options, IPublisher publisher) : base(options)
        {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }

        // TODO : documentarse sobre las migraciones de dbsets que son aggregates root

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var domainEvents = ChangeTracker.Entries<AggregateRoot>()
                    .Select(e => e.Entity)
                    .Where(e => e.GetDomainEvents().Any())
                    .SelectMany(e => e.GetDomainEvents());

            var result = await base.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            return result;
        }

    }
}
