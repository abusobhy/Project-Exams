using System;
using System.Collections.Generic;

namespace Domain.Entities
{
	public partial class TbSubjectsTaught:BaseTb
	{
	   

	    public string NameSubjects { get; set; } = null!;

	    public string? Description { get; set; }

	   

	    public virtual ICollection<TbExam> TbExams { get; set; } = new List<TbExam>();
	}
}
