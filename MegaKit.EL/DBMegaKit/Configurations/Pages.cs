using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaKit.EL.DBMegaKit.Configurations
{
    public class Pages : IEntityTypeConfiguration<Entites.Pages>
    {
        public void Configure(EntityTypeBuilder<Entites.Pages> builder)
        {
            builder.Property(x => x.Link).IsRequired();
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
