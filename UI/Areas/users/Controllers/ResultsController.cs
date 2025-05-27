using BL.Contracts;
using BL.Contracts.UserSevice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.users.Controllers
{
	[Area("users")]
	[Authorize(Roles = "Admin,Student")]
	public class ResultsController : Controller
	{
		private readonly IUserExam	_userExam;
		private readonly IExam	_exam;
		private readonly ISubjectsTaught _subjectsTaught;
		private readonly IUserService _userService;

		public ResultsController(IUserExam userExam, IExam exam, ISubjectsTaught subjectsTaught, IUserService userService)
		{
			_userExam = userExam;
			_exam = exam;
			_subjectsTaught = subjectsTaught;
			_userService = userService;
		}
		public IActionResult Index(Guid id)
		{

			var userExam = _userExam.GetById(id);
			var NameExam = _exam.GetById(userExam.ExamId);
			var NameSubject = _subjectsTaught.GetById(NameExam.SubjectTaughId).NameSubjects;


			ViewBag.NameExam = NameExam.Title;
			ViewBag.NameSubject = NameSubject;

			// الاسكور
			// النتيجه فالميه
			// ناجح/راسب
			// اسم الاختبار



			//+
			// العوده للصفحه الرئيسيه
			// برفايل 
			// ------ 
			return View(userExam);
		}
	}
}
