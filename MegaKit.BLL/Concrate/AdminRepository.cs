using MegaKit.BLL.Abstract;
using MegaKit.DAL.Concrate;
using MegaKit.DAL.Contexts;
using MegaKit.EL.DBMegaKit.Entites;

namespace MegaKit.BLL.Concrate
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        private readonly ContextMegaKit _context;

        public AdminRepository(ContextMegaKit context) : base(context)
        {
            _context = context;
        }
    }
}
