using BL.Contracts.UserSevice;
using Microsoft.AspNetCore.Mvc;

public class NavbarViewComponent : ViewComponent
{
    private readonly IUserService _userService;

    public NavbarViewComponent(IUserService userService)
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
	//public async Task<IViewComponentResult> InvokeAsync()
	//{

	//    if (!_userService.IsUserLoggedIn())
	//        return View("Guest");

	//    if (await _userService.IsUserInRoleAsync("Admin"))
	//        return View("Admin");

	//    if (await _userService.IsUserInRoleAsync("Student") || await _userService.IsUserInRoleAsync("Admin"))
	//        return View("Student");

	//    return View("Guest");
	//}
}
