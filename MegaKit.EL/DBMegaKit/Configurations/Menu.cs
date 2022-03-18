using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaKit.EL.DBMegaKit.Configurations
{
    public class Menu : IEntityTypeConfiguration<Entites.Menu>
    {
        public void Configure(EntityTypeBuilder<Entites.Menu> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Level).IsRequired();
            builder.Property(x => x.Link).IsRequired();
            builder.Property(x => x.SortId).IsRequired();
        }
    }
}
