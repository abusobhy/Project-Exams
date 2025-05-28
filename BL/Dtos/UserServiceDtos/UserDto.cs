using AppResources.Messages;
using BL.Dtos.Base;
using System.ComponentModel.DataAnnotations;


namespace BL.Dtos.UserServiceDtos
{
	public class UserDto : BaseDto
	{

		[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(message), AllowEmptyStrings = false)]
		public string? UserName { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(message), AllowEmptyStrings = false)]

        public string? Email { get; set; }
         
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(message), AllowEmptyStrings = false)]
        public string? Password { get; set; }
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(message), AllowEmptyStrings = false)]

        public string? ConfirmPassword { get; set; }
		public string? ReturnUrl { get; set; }
	}
}
