using BL.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;

namespace UI.Areas.users.Controllers
{

    [Area("users")]
    public class HomeUsersController : Controller
    {
        private readonly ILogger<HomeUsersController> _logger;
        private readonly ISubjectsTaught _subjects;

        public HomeUsersController(ISubjectsTaught subjects, ILogger<HomeUsersController> logger)
        {
            _subjects = subjects;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var Data = _subjects.GetAll();

            return View(Data);
        }

        public IActionResult Privacy()
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
