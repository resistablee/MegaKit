using MegaKit.BLL.Abstract;
using MegaKit.EL.DBMegaKit.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MegaKit.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IContactRepository _contactRepository;

        public TeamController(ITeamRepository teamRepository,
                               IContactRepository contactRepository)
        {
            _teamRepository = teamRepository;
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            var result = _teamRepository.GetAllAsync(x=>x.Status == true).Result;

            if (result.StatusCode == 404)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult Contact()
        {
            var result = _contactRepository.GetAllAsync(x => x.Status == true).Result;

            if (result.StatusCode == 404)
                return NotFound(result);

            return Ok(result);
        }
    }
}
