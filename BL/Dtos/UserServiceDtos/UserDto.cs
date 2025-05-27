using BL.Dtos.Base;


namespace BL.Dtos.UserServiceDtos
{
	public class UserDto : BaseDto
	{

		//[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
		//[StringLength(100, MinimumLength = 5, ErrorMessage = "NameLenght", ErrorMessageResourceType = typeof(Messages))]
		public string? UserName { get; set; }

		//[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
		//[EmailAddress]
		public string? Email { get; set; }


		//[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
		public string? Password { get; set; }

		//[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
		public string? ConfirmPassword { get; set; }
		public string? ReturnUrl { get; set; }
	}
}
