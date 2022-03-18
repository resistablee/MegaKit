using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaKit.EL.DBMegaKit.Configurations
{
    public class SocialMedia : IEntityTypeConfiguration<Entites.SocialMedia>
    {
        public void Configure(EntityTypeBuilder<Entites.SocialMedia> builder)
        {
            builder.Property(x => x.Link).IsRequired();
        }
    }
}
