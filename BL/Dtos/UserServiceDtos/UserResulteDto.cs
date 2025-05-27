

namespace BL.Dtos.UserServiceDtos
{
	public class UserResulteDto
	{

		public bool Success { get; set; }
		public string? Token { get; set; }
		public IEnumerable<string> Errors { get; set; }
	}
}
