using MegaKit.BLL.Abstract;
using MegaKit.DAL.Concrate;
using MegaKit.DAL.Contexts;
using MegaKit.EL.DBMegaKit.Entites;

namespace MegaKit.BLL.Concrate
{
    public class SliderRepository : GenericRepository<Slider>, ISliderRepository
    {
        private readonly ContextMegaKit _context;

        public SliderRepository(ContextMegaKit context) : base(context)
        {
            _context = context;
        }
    }
}
