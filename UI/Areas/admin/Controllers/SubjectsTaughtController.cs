using BL.Contracts;
using BL.Contracts.UserSevice;
using BL.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.admin.Controllers
{
	[Area("admin")]
	[Authorize(Roles = "Admin")]
	public class SubjectsTaughtController : Controller
	{
		private readonly ISubjectsTaught _SubjectsTaught;
		private readonly IExam _exams;
		private readonly IUserService _userService;
		public SubjectsTaughtController(ISubjectsTaught SubjectsTaught, IExam exams, IUserService userService)
		{
			_SubjectsTaught = SubjectsTaught;
			_exams = exams;
			_userService = userService;
		}
		public IActionResult Index()
		{
			var Data = _SubjectsTaught.GetAll().ToList();
			ViewBag.exams = _exams.GetAll().ToList();

			return View(Data);
		}


		public IActionResult Add(Guid? id)
		{

			var data = new SubjectsTaughtDto();
			if (id != null)
			{

				data = _SubjectsTaught.GetById((Guid)id);
			}
			return View(data);
		}
		
		
		public IActionResult Update(Guid? id)
		{


			var data = new SubjectsTaughtDto();
			if (id != null)
			{
				data = _SubjectsTaught.GetById((Guid)id);
			}
			return View(data);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Save(SubjectsTaughtDto data)
		{
			if (!ModelState.IsValid)
			{
				if (data.Id != Guid.Empty)
					return View("Update", data);
				else
					return View("Add", data);
			}
			



			if (data.Id == Guid.Empty)
				_SubjectsTaught.Add(data, data.Id);
			else
				_SubjectsTaught.Update(data, data.Id);

			return RedirectToAction("Index");
		}

		public IActionResult Delete(Guid id, int state = 0)
		{

			_SubjectsTaught.ChangeStatus(id, state);

			return Ok();
		}
	}
}
