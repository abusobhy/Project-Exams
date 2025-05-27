using BL.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;

namespace UI.Areas.admin.Controllers
{

    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class HomeAdminController : Controller
	{
		private readonly ILogger<HomeAdminController> _logger;
		private readonly ISubjectsTaught _subjects;
		private readonly IExam _exams;

		public HomeAdminController(ISubjectsTaught subjects, ILogger<HomeAdminController> logger, IExam exams)
		{
			_subjects = subjects;
			_logger = logger;
			_exams = exams;
		}

		public IActionResult Index()
		{
			var Data = _subjects.GetAll().ToList();
			ViewBag.exams = _exams.GetAll().ToList();

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
