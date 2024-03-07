using Domain.Models.Shared;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        //TODO: Terminar esta configuracion
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User")
                .HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasConversion<string>();

            builder.Property(e => e.FiscalType)
               .HasConversion(
                v => v.ToString(),
                v => (FiscalTypeEnum)Enum.Parse(typeof(FiscalTypeEnum), v))
               .IsRequired();

            builder.Property(x => x.FiscalNumber)
                 .HasConversion<string>()
                 .IsRequired()
                 .HasMaxLength(9);

            builder.Property(x => x.Name)
                .HasConversion<string>()
                .HasMaxLength(50);

            builder.Property(x => x.Address.Id)
                .HasConversion<string>()
                .HasMaxLength(9);

            builder.OwnsOne(a => a.Address, addressbuilder =>
            {
                addressbuilder.HasKey(s => s.Id);
                addressbuilder.Property(s => s.Id).HasConversion<string>();
                addressbuilder.Property(s => s.Street).HasConversion<string>();
                addressbuilder.Property(s => s.Number).HasConversion<string>();
                addressbuilder.Property(s => s.ZipCode).HasConversion<string>();
                addressbuilder.Property(s => s.Floor).HasConversion<string>();
                addressbuilder.Property(s => s.Letter).HasConversion<string>();
                addressbuilder.Property(s => s.City).HasConversion<string>();
                addressbuilder.Property(s => s.CountryCode).HasConversion<string>();


            });

            builder.Property(x => x.Phone)
                .HasConversion<string>()
                .HasMaxLength(9);



        }
    }
}
