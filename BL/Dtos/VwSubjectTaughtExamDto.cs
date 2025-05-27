

namespace BL.Dtos
{
	public partial class VwSubjectTaughtExamDto
	{
		public Guid Id { get; set; }

		public string Title { get; set; } = null!;

		public Guid SubjectTaughId { get; set; }

		public string NameSubjects { get; set; } = null!;
	}
}
