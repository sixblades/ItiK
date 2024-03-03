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
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasConversion(
                userId => userId,
                value => new Guid());

            builder.Property(e => e.FiscalType)
            .HasMaxLength(4)
            .HasConversion(
                v => v.ToString(),
                v => (FiscalTypeEnum)Enum.Parse(typeof(FiscalTypeEnum), v))
                .IsUnicode(false);

            //builder.Property(x => x.FiscalNumber).HasConversion(
            //    fiscalNumber => fiscalNumber,
            //    value => FiscalNumber.Create(value)!)
            //    .HasMaxLength(9);


        }
    }
}
