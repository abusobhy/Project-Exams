using BL.Contracts.UserSevice;
using BL.Dtos.UserServiceDtos;
using DAL.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UI.Areas.admin.Controllers
{
    [Area("admin")]

    public class AccountController : Controller
    {
        IUserService _userService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(IUserService userService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
        }
       
        public IActionResult Login(string returnUrl)
        {

            UserDto userDto = new UserDto()
            {
                ReturnUrl = returnUrl
            };
            return View(userDto);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Redirect("~/");
            //return RedirectToAction("Login");
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserDto userDto)
        {

            //if (userDto.Id != Guid.Empty)
            //    return RedirectToRoute(new { area = "admin", Controller = "Home" });

            if (!ModelState.IsValid)
                return View("Login", userDto);


            var result = await _userService.LoginAsync(userDto);
            if (result.Success)
            {
                if (string.IsNullOrEmpty(userDto.ReturnUrl))
                    return Redirect("~/");
                else
                    return Redirect(userDto.ReturnUrl);
                //return RedirectToRoute(new { area = "admin", Controller = "Account" });

            }
            else
            {

                return View(userDto);
            }
        }
        public IActionResult AccessDenied()
        {
            return View("access-denied");
        }

        public IActionResult Register(string returnUrl)
        {


            return View(new UserDto() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            if (!ModelState.IsValid)
                return View("Register", userDto);
            try
            {
                var resulte = await _userService.RegisterAsync(userDto);
                if (resulte.Success)
                {
                    var MyUser = await _userManager.FindByEmailAsync(userDto.Email);
                    await _userManager.AddToRoleAsync(MyUser, "Student");

                    return Redirect("~/");

                }
                else
                {

                }


                //return RedirectToRoute(new { area = "", Controller = "" });


            }
            catch (Exception ex)
            {

            }


            return View();
        }
    }
}
