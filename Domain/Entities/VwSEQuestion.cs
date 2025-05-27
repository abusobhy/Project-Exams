using System;
using System.Collections.Generic;

namespace Domain.Entities
{
	public partial class VwSEQuestion
	{
		public string Title { get; set; } = null!;

		public Guid SubjectTaughId { get; set; }

		public string NameSubjects { get; set; } = null!;

		public Guid ExamId { get; set; }

		public Guid Id { get; set; }

		public string Expr1 { get; set; } = null!;

		public string RightAnswer { get; set; } = null!;
	}
}
