using BL.Contracts.UserSevice;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents
{
    public class CurrentUserViewComponent : ViewComponent
    {
        private readonly IUserService _userService;
        public CurrentUserViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = _userService.GetUserByHttp();
            var user = await _userService.GetUserByIdAsync(userId);
            return View("Default", user);
        }
    }
}
