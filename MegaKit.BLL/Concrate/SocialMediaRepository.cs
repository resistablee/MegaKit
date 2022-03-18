using MegaKit.BLL.Abstract;
using MegaKit.DAL.Concrate;
using MegaKit.DAL.Contexts;
using MegaKit.EL.DBMegaKit.Entites;

namespace MegaKit.BLL.Concrate
{
    public class SocialMediaRepository : GenericRepository<SocialMedia>, ISocialMediaRepository
    {
        private readonly ContextMegaKit _context;

        public SocialMediaRepository(ContextMegaKit context) : base(context)
        {
            _context = context;
        }
    }
}
