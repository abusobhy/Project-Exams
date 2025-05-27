using System;
using System.Collections.Generic;

namespace Domain.Entities
{
	public partial class TbExam:BaseTb
	{

		public string Title { get; set; } = null!;

		public string? Description { get; set; }

		public Guid SubjectTaughId { get; set; }

		

		public virtual TbSubjectsTaught SubjectTaugh { get; set; } = null!;

		public virtual ICollection<TbQuestion> TbQuestions { get; set; } = new List<TbQuestion>();

		public virtual ICollection<TbUserExam> TbUserExams { get; set; } = new List<TbUserExam>();
	}
}
