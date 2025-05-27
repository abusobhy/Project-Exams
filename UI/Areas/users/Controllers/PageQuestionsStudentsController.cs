using AppResources.Exam;
using BL.Contracts;
using BL.Contracts.UserSevice;
using BL.Dtos;
using BL.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace UI.Areas.users.Controllers
{
	[Area("users")]
	[Authorize(Roles = "Admin,Student")]
	public class PageQuestionsStudentsController : Controller
	{
		private readonly IQuestion _question;
		private readonly IUserAnswer _userAnswer;
		private readonly IUserExam _userExam;
		private readonly IUserService _userService;

		public PageQuestionsStudentsController(IUserService userService, IUserExam userExam, IQuestion question, IUserAnswer userAnswer)
		{
			_userAnswer = userAnswer;
			_userService = userService;
			_userExam = userExam;
			_question = question;
		}

		public IActionResult StartExam(Guid id, Guid userId)
		{
			var dataUserExam = _userExam.FillingUserExamDto(id, _userService.GetLoggedInUser());



			_userExam.Add(dataUserExam, _userService.GetLoggedInUser());

			var data = _question.QuestionNow(id, 1);

			return View(data);
		}

		[HttpPost]
		public IActionResult SaveAjax([FromBody] QuestionDto questionDto, Guid userId)
		{
			
			var dataUserExam = _userExam.OneUserExamDto(_userService.GetLoggedInUser());

			var dataUserAnswer = _userAnswer.OneUserAnswerDto(dataUserExam.Id);

			var newQuestion = _question.QuestionNow(questionDto.ExamId, questionDto.QuestionOrder);

			var data = _userAnswer.SendAfterCheckingTheAnswer(dataUserAnswer, questionDto, dataUserExam, newQuestion.RightAnswer);

			_userAnswer.Add(data, userId);

			var nextQuestion = _question.GetNextQuestionId(questionDto.ExamId, questionDto.QuestionOrder);

			if (nextQuestion == null )
			{

				dataUserExam.Score = _userAnswer.ResultFromUserAnswer(dataUserExam.Id);

				


				float resQuestions = _question.GetAll().Where(a => a.ExamId == dataUserExam.ExamId).Count();

				float result = (dataUserExam.Score / resQuestions) * 100;
				dataUserExam.Resultes = result;

				if (result >= 60)
					dataUserExam.PassStatus = true;
				else
					dataUserExam.PassStatus = false;
				dataUserExam.EndTime = DateTime.Now;
				dataUserExam.CurrentState = 0;

				_userExam.Update(dataUserExam, dataUserExam.UserId);

				return RedirectToAction("Index", "Results", new { id = dataUserExam.Id });

			}
				return PartialView("_QuestionsList", nextQuestion);
			
		}

		public IActionResult Index(QuestionDto questionDto)
		{


			return View(questionDto);
		}


	}
}
