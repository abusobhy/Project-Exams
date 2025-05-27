using BL.Dtos.Base;


namespace BL.Dtos
{
	public partial class UserExamDto : BaseDto
	{



		public Guid ExamId { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime? EndTime { get; set; }

		public int Score { get; set; }
		public float? Resultes { get; set; }

		public bool? PassStatus { get; set; }
		public Guid UserId { get; set; } 



	}
}
