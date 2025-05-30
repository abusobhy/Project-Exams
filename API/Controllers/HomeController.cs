using BL.Contracts;
using BL.Dtos;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
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



		// GET: api/<HomeController>
		[HttpGet]
		public IEnumerable<SubjectsTaughtDto> Get()
		{
			return _subjects.GetAll().ToList();
		}

		// GET api/<HomeController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<HomeController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<HomeController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<HomeController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
