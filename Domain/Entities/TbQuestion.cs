using System;
using System.Collections.Generic;

namespace Domain.Entities
{
	public partial class TbQuestion:BaseTb
	{

		public Guid ExamId { get; set; }

		public string Title { get; set; } = null!;

		public string Choice1 { get; set; } = null!;

		public string Choice2 { get; set; } = null!;

		public string Choice3 { get; set; } = null!;

		public string Choiec4 { get; set; } = null!;

		public string RightAnswer { get; set; } = null!;

		public int QuestionOrder { get; set; }

		
		public virtual TbExam Exam { get; set; } = null!;

		public virtual ICollection<TbUserAnswer> TbUserAnswers { get; set; } = new List<TbUserAnswer>();
	}
}
