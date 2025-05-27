using BL.Contracts.UserSevice;
using Microsoft.AspNetCore.Mvc;

public class SidebarViewComponent : ViewComponent
{
    private readonly IUserService _userService;

    public SidebarViewComponent(IUserService userService)
    {
        _userService = userService;
    }

	public async Task<IViewComponentResult> InvokeAsync()
	{
		if (!await _userService.GetLoggedInUserAsync())
			return View("Guest");

		var isAdmin = await _userService.IsUserInRoleAsync("Admin");
		var isStudent = await _userService.IsUserInRoleAsync("Student");

		if (isAdmin)
			return View("Admin");

		if (isStudent)
			return View("Student");

		return View("Guest");
	}
}
