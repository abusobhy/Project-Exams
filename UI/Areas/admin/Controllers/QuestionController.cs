using BL.Contracts;
using BL.Contracts.UserSevice;
using BL.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class QuestionController : Controller
    {
        private readonly IExam _exam;
        private readonly IQuestion _question;
		public QuestionController(IExam exam, IQuestion question)
		{
			_exam = exam;
			_question = question;
		}
		public IActionResult Index(Guid id)
        {

			var data = _question.GetAll().ToList();
			ViewBag.exam = _exam.GetAll().FirstOrDefault(a=>a.Id == id)?.Title;
            ViewBag.examId = id; 
			if (id != Guid.Empty)
			{
				data = data.Where(a => a.ExamId == id).ToList();
			}

			return View(data);
        }
		public IActionResult ShowAll()
		{
			return RedirectToAction("Index",new {id=Guid.Empty});
		}

		private QuestionDto LastQuestion(Guid? examId)
        {
            var LastQuestion = _question.GetAll().ToList().OrderByDescending(q=>q.QuestionOrder).FirstOrDefault();
            return LastQuestion;

		}

		public IActionResult Add(Guid? id)
        {
            ViewBag.examId = id;
			var data = new QuestionDto();
           
            return View(data);
        }
		
		public IActionResult Update(Guid? id)
        {

			var data = new QuestionDto();
            if (id != null)
            {
                data = _question.GetById((Guid)id);
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(QuestionDto data)
        {

			if (!ModelState.IsValid)
			{
				if (data.Id != Guid.Empty)
					return View("Update", data);
				else
					return View("Add", data);
			}

			var lastQustion = LastQuestion(data.ExamId);

			if (data.Id == Guid.Empty)
            {
                if (lastQustion == null)
                {
                    data.QuestionOrder = 1;
                }
                else
                {

			        data.QuestionOrder = lastQustion.QuestionOrder + 1;
                }

				_question.Add(data, data.Id);
            }
            else
				_question.Update(data, data.Id);

            return RedirectToAction("Index", new {id= data.ExamId});
        }

        public IActionResult Delete(Guid id, int state = 0)
        {

            _question.ChangeStatus(id, state);

            return Ok();
        }
    }
}
