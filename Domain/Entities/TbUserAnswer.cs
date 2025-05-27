using System;
using System.Collections.Generic;

namespace Domain.Entities
{
	public partial class TbUserAnswer:BaseTb
	{

	    public Guid UserExamId { get; set; }

	    public Guid QuestionId { get; set; }

	    public string? SelectedAnswer { get; set; }

	    public bool? IsCorrect { get; set; }
	    public int Result { get; set; }


	    public virtual TbQuestion Question { get; set; } = null!;

	    public virtual TbUserExam UserExam { get; set; } = null!;
	}
}
