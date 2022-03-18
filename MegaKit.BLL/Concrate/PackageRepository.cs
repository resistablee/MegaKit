using MegaKit.BLL.Abstract;
using MegaKit.DAL.Concrate;
using MegaKit.DAL.Contexts;
using MegaKit.EL.DBMegaKit.Entites;

namespace MegaKit.BLL.Concrate
{
    public class PackageRepository : GenericRepository<Packages>, IPackageRepository
    {
        private readonly ContextMegaKit _context;

        public PackageRepository(ContextMegaKit context) : base(context)
        {
            _context = context;
        }
    }
}
