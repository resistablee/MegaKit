using MegaKit.BLL.Abstract;
using MegaKit.DAL.Concrate;
using MegaKit.DAL.Contexts;
using MegaKit.EL.DBMegaKit.Entites;

namespace MegaKit.BLL.Concrate
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        private readonly ContextMegaKit _context;

        public TeamRepository(ContextMegaKit context) : base(context)
        {
            _context = context;
        }
    }
}
