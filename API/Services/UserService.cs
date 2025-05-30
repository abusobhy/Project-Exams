using BL.Contracts.UserSevice;
using BL.Dtos.UserServiceDtos;
using DAL.UserModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;


namespace API.Services
{
	public class UserService : IUserService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UserService(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userMagager, SignInManager<ApplicationUser> signInMagager)
		{
			_httpContextAccessor = httpContextAccessor;
			_userManager = userMagager;
			_signInManager = signInMagager;
		}


		public async Task<UserResulteDto> RegisterAsync(UserDto registerDto)
		{
			if (registerDto.Password != registerDto.ConfirmPassword)
			{
				return new UserResulteDto
				{
					Success = false,
					Errors = new[] { "Password do not match ." }
				};
			}
			var user = new ApplicationUser { UserName = registerDto.Email, Email = registerDto.Email };

			var result = await _userManager.CreateAsync(user, registerDto.Password);
			//var result2 = await _userManager
			return new UserResulteDto { Success = result.Succeeded, Errors = result.Errors?.Select(e => e.Description) };
		}

		public async Task<UserResulteDto> LoginAsync(UserDto loginDto)
		{
			var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, true, true);
			if (!result.Succeeded)
			{
				return new UserResulteDto
				{
					Success = false,
					Errors = new[] { "Invalid Login attemp ." }
				};
			}
			return new UserResulteDto { Success = true, Token = "DummyTokenForNow" };
		}


		public async Task LogoutAsync()
		{
			await _signInManager.SignOutAsync();
		}
		public async Task<bool> IsExsistUser(string email)
		{


			var result = await _userManager.FindByEmailAsync(email);
			if (result.Email == null)
				return false;

			return true;

		}
		public string GetUserByHttp()
		{
			return _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
		}

		public async Task<UserDto> GetUserByIdAsync(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null) return null;

			return new UserDto
			{
				Id = Guid.Parse(user.Id),
				Email = user.Email
			};

		}

		public async Task<IEnumerable<UserDto>> GetAllUserAsync()
		{
			var users = _userManager.Users;
			return users.Select(u => new UserDto
			{
				Id = Guid.Parse(u.Id),
				Email = u.Email
			});
		}

		public Guid GetLoggedInUser()
		{
			var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
			return Guid.Parse(userId);
		}

		public async Task<bool> GetLoggedInUserAsync()
		{
			var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
			return userId.IsNullOrEmpty() ? false : true;
		}

		public bool IsUserLoggedIn()
		{
			var user = _httpContextAccessor.HttpContext?.User;
			return _signInManager.IsSignedIn(user);
		}

		public async Task<bool> IsUserInRoleAsync(string roleName)
		{
			var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
			return user != null && await _userManager.IsInRoleAsync(user, roleName);
		}
	}
}
