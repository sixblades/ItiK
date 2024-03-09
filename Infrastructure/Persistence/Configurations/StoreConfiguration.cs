using Domain.Models.Shared;
using Domain.Models.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Store")
                .HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasConversion<string>();

            builder.Property(e => e.FiscalTypeEnum)
               .HasConversion(
                v => v.ToString(),
                v => (FiscalTypeEnum)Enum.Parse(typeof(FiscalTypeEnum), v))
               .IsRequired();

            builder.Property(x => x.FiscalNumber)
                 .HasConversion<string>()
                 .IsRequired()
                 .HasMaxLength(9);

            builder.Property(x => x.StoreName)
                .HasConversion<string>()
                .HasMaxLength(50);

            builder.Property(x => x.StoreAddress.Id)
                .HasConversion<string>()
                .HasMaxLength(9);

            builder.OwnsOne(a => a.StoreAddress, addressbuilder =>
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

            builder.Property(x => x.StorePhone)
                .HasConversion<string>()
                .HasMaxLength(9);



        }
    }
}
