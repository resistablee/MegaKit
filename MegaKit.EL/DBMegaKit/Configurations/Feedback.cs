using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaKit.EL.DBMegaKit.Configurations
{
    public class Feedback : IEntityTypeConfiguration<Entites.Feedback>
    {
        public void Configure(EntityTypeBuilder<Entites.Feedback> builder)
        {
            builder.Property(x => x.NameSurname).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Text).IsRequired();
        }
    }
}
