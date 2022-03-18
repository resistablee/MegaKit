using MegaKit.BLL.Abstract;
using MegaKit.DAL.Concrate;
using MegaKit.DAL.Contexts;
using MegaKit.EL.DBMegaKit.Entites;

namespace MegaKit.BLL.Concrate
{
    public class CustomerRepository : GenericRepository<Customers>, ICustomerRepository
    {
        private readonly ContextMegaKit _context;

        public CustomerRepository(ContextMegaKit context) : base(context)
        {
            _context = context;
        }
    }
}
