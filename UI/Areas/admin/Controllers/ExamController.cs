using BL.Contracts;
using BL.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles ="Admin")]
    public class ExamController : Controller
    {
        private readonly IExam _Exam;
        private readonly IQuestion _question;
        private readonly ISubjectsTaught _subjectsTaught;

		public ExamController(IExam Exam, IQuestion question, ISubjectsTaught subjectsTaught)
		{
			_Exam = Exam;
			_question = question;
			_subjectsTaught = subjectsTaught;
		}

		public IActionResult Index(Guid? id)
        {
			var data = _Exam.GetAll().ToList();
			ViewBag.ques = _question.GetAll().ToList();
			ViewBag.subj = _subjectsTaught.GetAll().ToList();
			ViewBag.subjId= Guid.Empty;

			if (id != Guid.Empty)
            {
			    ViewBag.subjId = id;
				ViewBag.subjName = _subjectsTaught.GetAll().FirstOrDefault(a => a.Id == id)?.NameSubjects;
				data = data.Where(a => a.SubjectTaughId == id).ToList();
            }
            
            return View(data);
        }
        
        public IActionResult ShowAll()
        {
            return RedirectToAction("Index", new { id = Guid.Empty });
        }

        
        public IActionResult Add(Guid? id)
        {

			ViewBag.subjId = id;
            if (id != Guid.Empty)
                ViewBag.subj = _subjectsTaught.GetAll().FirstOrDefault(a=>a.Id== id)?.NameSubjects;
            else
				ViewBag.subj = _subjectsTaught.GetAll().ToList();

			var data = new ExamDto();
			return View(data);
        }
		
		public IActionResult Update(Guid? id)
        {
            var data = new ExamDto();
            if (id != null)
            {
                data = _Exam.GetById((Guid)id);
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(ExamDto data)
        {

			if (!ModelState.IsValid)
			{
				if (data.Id != Guid.Empty)
					return View("Update", data);
				else
					return View("Add", data);
			}



			if (data.Id == Guid.Empty)
                _Exam.Add(data, data.Id);
            else
                _Exam.Update(data, data.Id);
                
            return RedirectToAction("Index", new {id=data.SubjectTaughId});
        }

        public IActionResult Delete(Guid id, int state = 0)
        {

            _Exam.ChangeStatus(id, state);

            return Ok();
        }
    }
}
