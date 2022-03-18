using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaKit.EL.DBMegaKit.Configurations
{
    public class Packages : IEntityTypeConfiguration<Entites.Packages>
    {
        public void Configure(EntityTypeBuilder<Entites.Packages> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.ImageURL).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.SortId).IsRequired();
        }
    }
}
