using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaKit.EL.DBMegaKit.Configurations
{
    public class Slider : IEntityTypeConfiguration<Entites.Slider>
    {
        public void Configure(EntityTypeBuilder<Entites.Slider> builder)
        {
            builder.Property(x => x.PageID).IsRequired();
            builder.Property(x => x.SortId).IsRequired();
        }
    }
}
