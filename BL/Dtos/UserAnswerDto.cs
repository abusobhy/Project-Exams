using BL.Dtos.Base;
using System.ComponentModel.DataAnnotations;

namespace BL.Dtos
{
	public partial class UserAnswerDto : BaseDto
	{

		public Guid UserExamId { get; set; }

		public Guid QuestionId { get; set; }
		public string? SelectedAnswer { get; set; }

		public bool? IsCorrect { get; set; }

		public int Result { get; set; } 




	}
}
