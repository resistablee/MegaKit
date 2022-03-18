using MegaKit.BLL.Abstract;
using MegaKit.DAL.Concrate;
using MegaKit.DAL.Contexts;
using MegaKit.EL.DBMegaKit.Entites;

namespace MegaKit.BLL.Concrate
{
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        private readonly ContextMegaKit _context;

        public MenuRepository(ContextMegaKit context) : base(context)
        {
            _context = context;
        }
    }
}
