using MegaKit.BLL.Abstract;
using MegaKit.DAL.Concrate;
using MegaKit.DAL.Contexts;
using MegaKit.EL.DBMegaKit.Entites;

namespace MegaKit.BLL.Concrate
{
    public class PageRepository : GenericRepository<Pages>, IPageRepository
    {
        private readonly ContextMegaKit _context;

        public PageRepository(ContextMegaKit context) : base(context)
        {
            _context = context;
        }
    }
}
