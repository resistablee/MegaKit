using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaKit.EL.DBMegaKit.Configurations
{
    public class Contact : IEntityTypeConfiguration<Entites.Contact>
    {
        public void Configure(EntityTypeBuilder<Entites.Contact> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.URL).IsRequired();
            builder.Property(x => x.ImageURL).IsRequired();
            builder.Property(x => x.SortId).IsRequired();
        }
    }
}
