using MegaKit.BLL.Abstract;
using MegaKit.DAL.Concrate;
using MegaKit.DAL.Contexts;
using MegaKit.EL.DBMegaKit.Entites;

namespace MegaKit.BLL.Concrate
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        private readonly ContextMegaKit _context;

        public ContactRepository(ContextMegaKit context) : base(context)
        {
            _context = context;
        }
    }
}
