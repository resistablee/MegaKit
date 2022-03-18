using MegaKit.BLL.Abstract;
using MegaKit.DAL.Concrate;
using MegaKit.DAL.Contexts;
using MegaKit.EL.DBMegaKit.Entites;

namespace MegaKit.BLL.Concrate
{
    public class FeedBackRepository : GenericRepository<Feedback>, IFeedBackRepository
    {
        private readonly ContextMegaKit _context;

        public FeedBackRepository(ContextMegaKit context) : base(context)
        {
            _context = context;
        }
    }
}
