using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class CarMapping : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Plaque)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(c => c.Owner)
                .IsRequired();

            builder.Property(c => c.Stolen)
                .IsRequired();

            builder.Property(c => c.YearOfManufacture)
                .IsRequired();

            builder.Property(c => c.YearModel)
                .IsRequired();

            builder.Property(c => c.DateRegister)
                .IsRequired();

            builder.ToTable("Cars");
        }
    }
}
