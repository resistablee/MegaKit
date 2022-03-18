using MegaKit.BLL.Abstract;
using MegaKit.DAL.Concrate;
using MegaKit.DAL.Contexts;
using MegaKit.EL.DBMegaKit.Entites;

namespace MegaKit.BLL.Concrate
{
    public class CommentRepository : GenericRepository<Comments>, ICommentRepository
    {
        private readonly ContextMegaKit _context;

        public CommentRepository(ContextMegaKit context) : base(context)
        {
            _context = context;
        }
    }
}
