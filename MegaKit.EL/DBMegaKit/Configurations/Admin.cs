using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaKit.EL.DBMegaKit.Configurations
{
    public class Admin : IEntityTypeConfiguration<Entites.Admin>
    {
        public void Configure(EntityTypeBuilder<Entites.Admin> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Surname).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Telno).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Authority).IsRequired();

            builder.Property(x => x.Telno).HasMaxLength(11);
            builder.Property(x => x.Password).HasMaxLength(20);
        }
    }
}
