using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaKit.EL.DBMegaKit.Configurations
{
    public class Customers : IEntityTypeConfiguration<Entites.Customers>
    {
        public void Configure(EntityTypeBuilder<Entites.Customers> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.Link).IsRequired();
            builder.Property(x => x.ImageURL).IsRequired();
            builder.Property(x => x.SortId).IsRequired();
        }
    }
}
