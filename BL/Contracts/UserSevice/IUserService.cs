using BL.Dtos.UserServiceDtos;

namespace BL.Contracts.UserSevice
{
	public interface IUserService
	{
		Task<UserResulteDto> RegisterAsync(UserDto registerDto);
		Task<UserResulteDto> LoginAsync(UserDto registerDto);
		Task LogoutAsync();
		Task<bool> IsExsistUser(string email);
		Task<UserDto> GetUserByIdAsync(string userId);
		Task<IEnumerable<UserDto>> GetAllUserAsync();
		Guid GetLoggedInUser();
		public bool IsUserLoggedIn();
		public Task<bool> IsUserInRoleAsync(string roleName);
		public string GetUserByHttp();
		public Task<bool> GetLoggedInUserAsync();




	}
}
