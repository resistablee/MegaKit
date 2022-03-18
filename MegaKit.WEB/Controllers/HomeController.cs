using MegaKit.EL;
using MegaKit.EL.DBMegaKit.Entites;
using MegaKit.EL.DTO;
using MegaKit.WEB.Models;
using MegaKit.WEB.Models.HttpClientFactory.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MegaKit.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITeamService _teamService;

        public HomeController(ILogger<HomeController> logger,
                               ITeamService teamService)
        {
            _logger = logger;
            _teamService = teamService;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("About")]
        public IActionResult About()
        {
            return View();
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }


        [Route("Team")]
        public IActionResult Team()
        {
            ReturnValue<IList<Team>> TeamList = _teamService.GetTeam().Result;
            ReturnValue<IList<Contact>> ContactList = _teamService.GetContact().Result;

            TeamDTO teamDTO = new TeamDTO();
            teamDTO.Team = TeamList.Data;
            teamDTO.Contact = ContactList.Data.OrderBy(x => x.SortId).ToList();

            return View(teamDTO);

            teamDTO.Dispose();
        }

        [Route("Packages")]
        public IActionResult Packages()
        {
            return View();
        }

        [Route("Projects")]
        public IActionResult Projects()
        {
            return View();
        }


        [Route("FAQ")]
        public IActionResult FAQ()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
