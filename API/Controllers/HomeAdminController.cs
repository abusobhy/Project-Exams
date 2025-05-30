using BL.Contracts;
using BL.Dtos;
using Microsoft.AspNetCore.Mvc;



namespace API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class HomeAdminController : ControllerBase
	{
		private readonly ILogger<HomeAdminController> _logger;
		private readonly IVwSEQuestion _vwSEQuestion;

		public HomeAdminController(ILogger<HomeAdminController> logger, IVwSEQuestion vwSEQuestion)
		{
			_logger = logger;
			_vwSEQuestion = vwSEQuestion;
		}

		// GET: api/<HomeController>
		[HttpGet]
		public IEnumerable<VwSEQuestionDto> GetSubjectsExamsQuestions()
		{
			return _vwSEQuestion.GetAll().ToList();
		}

		
	}
}
