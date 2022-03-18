using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaKit.EL.DBMegaKit.Configurations
{
    public class Comments : IEntityTypeConfiguration<Entites.Comments>
    {
        public void Configure(EntityTypeBuilder<Entites.Comments> builder)
        {
            builder.Property(x => x.Comment).IsRequired();
            builder.Property(x => x.Author).IsRequired();
            builder.Property(x => x.AuthorCompany).IsRequired();
        }
    }
}
