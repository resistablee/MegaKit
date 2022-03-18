using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaKit.EL.DBMegaKit.Configurations
{
    public class Team : IEntityTypeConfiguration<Entites.Team>
    {
        public void Configure(EntityTypeBuilder<Entites.Team> builder)
        {
            builder.Property(x => x.NameSurname).IsRequired();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.Level).IsRequired();
            builder.Property(x => x.ImageURL).IsRequired();
        }
    }
}
