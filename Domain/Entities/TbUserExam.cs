using System;
using System.Collections.Generic;

namespace Domain.Entities
{
	public partial class TbUserExam : BaseTb
	{
	    


	    public Guid ExamId { get; set; }
	    public Guid UserId { get; set; }

	    public DateTime StartTime { get; set; }

	    public DateTime? EndTime { get; set; }

	    public int Score { get; set; }
	    public float? Resultes { get; set; }

	    public bool? PassStatus { get; set; }

	    

	    public virtual TbExam Exam { get; set; } = null!;

		public virtual ICollection<TbUserAnswer> TbUserAnswers { get; set; } = new List<TbUserAnswer>();
	}
}
