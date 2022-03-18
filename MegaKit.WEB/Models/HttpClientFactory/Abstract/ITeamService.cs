using MegaKit.EL;
using MegaKit.EL.DBMegaKit.Entites;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaKit.WEB.Models.HttpClientFactory.Abstract
{
    public interface ITeamService
    {
        Task<ReturnValue<IList<Team>>> GetTeam();
        Task<ReturnValue<IList<Contact>>> GetContact();
    }
}
