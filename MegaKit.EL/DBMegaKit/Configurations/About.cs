using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaKit.EL.DBMegaKit.Configurations
{
    public class About : IEntityTypeConfiguration<Entites.About>
    {
        public void Configure(EntityTypeBuilder<Entites.About> builder)
        {
            //Configurations
        }
    }
}
