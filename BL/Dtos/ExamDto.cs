using AppResources.Messages;
using BL.Dtos.Base;
using System.ComponentModel.DataAnnotations;


namespace BL.Dtos
{
	public partial class ExamDto : BaseDto
	{
		[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(message), AllowEmptyStrings = false)]
		public string Title { get; set; } = null!;

		public string? Description { get; set; }

		public Guid SubjectTaughId { get; set; }


	}
}
