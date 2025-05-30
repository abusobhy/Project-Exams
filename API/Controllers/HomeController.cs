using BL.Contracts;
using BL.Dtos;
using Microsoft.AspNetCore.Mvc;



namespace API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IVwSubjectTaughtExam _vwSubjectTaughtExams;

		public HomeController(ILogger<HomeController> logger, IVwSubjectTaughtExam vwSubjectTaughtExams)
		{
			_logger = logger;
			_vwSubjectTaughtExams = vwSubjectTaughtExams;
		}



		// GET: api/<HomeController>
		[HttpGet]
		public IEnumerable<VwSubjectTaughtExamDto> GetSubjectsExams()
		{
			return _vwSubjectTaughtExams.GetAll().ToList();
		}
	

		
	}
}
