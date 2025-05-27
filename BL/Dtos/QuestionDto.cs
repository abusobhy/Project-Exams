using AppResources.Messages;
using BL.Dtos.Base;
using System.ComponentModel.DataAnnotations;


namespace BL.Dtos
{
	public partial class QuestionDto : BaseDto
	{

		public Guid ExamId { get; set; }
		[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(message), AllowEmptyStrings = false)]

		public string Title { get; set; } = null!;
		[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(message), AllowEmptyStrings = false)]

		public string Choice1 { get; set; } = null!;
		[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(message), AllowEmptyStrings = false)]

		public string Choice2 { get; set; } = null!;
		[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(message), AllowEmptyStrings = false)]

		public string Choice3 { get; set; } = null!;
		[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(message), AllowEmptyStrings = false)]

		public string Choiec4 { get; set; } = null!;

		public int QuestionOrder { get; set; }

		[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(message), AllowEmptyStrings = false)]

		public string RightAnswer { get; set; } = null!;



	}
}
