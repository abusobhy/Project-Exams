

namespace Domain.Entities
{
	public partial class VwSubjectTaughtExam
	{
		public Guid Id { get; set; }

		public string Title { get; set; } = null!;

		public Guid SubjectTaughId { get; set; }

		public string NameSubjects { get; set; } = null!;
	}
}
