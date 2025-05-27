using AppResources.Messages;
using BL.Dtos.Base;
using System.ComponentModel.DataAnnotations;


namespace BL.Dtos
{
	public partial class SubjectsTaughtDto : BaseDto
	{

		
		[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(message), AllowEmptyStrings = false)]
		public string NameSubjects { get; set; } = null!;

		public string? Description { get; set; }



	}
}
