using MegaKit.BLL.Abstract;
using MegaKit.DAL.Concrate;
using MegaKit.DAL.Contexts;
using MegaKit.EL.DBMegaKit.Entites;

namespace MegaKit.BLL.Concrate
{
    public class AboutRepository : GenericRepository<About>, IAboutRepository
    {
        private readonly ContextMegaKit _context;

        public AboutRepository(ContextMegaKit context) : base(context)
        {
            _context = context;
        }
    }
}
