using BL.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Areas.admin.Controllers;
using UI.Models;

namespace UI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ISubjectsTaught _subjects;
		//private readonly IQuestion _question;
		private readonly IExam _exams;

		public HomeController(ISubjectsTaught subjects, ILogger<HomeController> logger, IExam exams)
		{
			_subjects = subjects;
			_logger = logger;
			_exams = exams;
			//_question = question;
		}

		public IActionResult Index()
		{
			var Data = _subjects.GetAll().ToList();
			ViewBag.exams = _exams.GetAll().ToList();

			return View(Data);
		}
       
        public IActionResult ShowExams(Guid id)
		{
            var data = _exams.GetAll().ToList();
            //ViewBag.ques = _question.GetAll().ToList();
            ViewBag.subj = _subjects.GetAll().ToList();
            ViewBag.subjId = Guid.Empty;

            if (id != Guid.Empty)
            {
                ViewBag.subjId = id;
                ViewBag.subjName = _subjects.GetAll().FirstOrDefault(a => a.Id == id)?.NameSubjects;
                data = data.Where(a => a.SubjectTaughId == id).ToList();
            }

            return View(data);
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
